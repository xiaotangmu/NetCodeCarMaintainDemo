using DAO.Sku;
using DateModel.Sku;
using Interface.Sku;
using Supervisor.Sku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.CustomException;
using ViewModel.Sku;

namespace BLL.Sku
{
    public class OutSupervisor: BaseBLL, IOutSupervisor
    {
        private IOutRepository _outDao;
        private ISkuRepository _skuDao;
        public OutSupervisor(IOutRepository outDao = null, ISkuRepository skuDao = null)
        {
            _outDao = InitDAO<OutDao>(outDao) as IOutRepository;
            _skuDao = new SkuDao(_outDao.Repository);
        }

        public async Task<bool> Delete(string Id)
        {
            return await _outDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 1. 删除关联Sku
                await _outDao.DeleteOutSkuByOutId(Id, transaction);
                // 2. 删除out
                return await _outDao.DeleteOutById(Id, transaction);
            });
        }
        public async Task<bool> DeleteBatch(IEnumerable<OutDeleteModel> modelList)
        {
            return await _outDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                foreach (var model in modelList)
                {
                    if (string.IsNullOrWhiteSpace(model.Id))
                    {
                        throw new MyServiceException("数据异常");
                    }
                    await _outDao.DeleteOutSkuByOutId(model.Id, transaction);
                    await _outDao.DeleteOutById(model.Id, transaction);
                }
                return true;
            });
        }
        public async Task<string> Add(OutAddModel model)
        {
            // 1. 查重
            IEnumerable<OutSkuAddModel> outSkuList = model.outSkuList;
            IsRepeatAndThrowException(outSkuList);
            // 3. 查是否存在
            bool exist = await _outDao.IsExistByOutNo(model.OutNo);
            if (exist)
            {
                throw new MyServiceException(MsgCode.SameData, "该批次出库单已经添加");
            }
            // 判断库存是否足够
            foreach(var outSku in outSkuList)
            {
                bool enough = await _outDao.CheckSkuIsEnough(outSku);
                if (!enough)
                {
                    throw new Exception("库存不足，出库失败");
                }
            }
            // 记录查询是否报警的addressIdSet，方便最后查询
            HashSet<string> addressIdSet = new HashSet<string>();
            string outId1 = await _outDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                decimal Total = 0;
                // 计算总金额
                foreach (var entrySku in outSkuList)
                {
                    entrySku.TotalPrice = entrySku.Quantity * entrySku.Price;
                    Total += entrySku.TotalPrice;
                }
                // 添加出库单
                string outId = await _outDao.Insert(ModelToEntityNoId(model), transaction);
                // 添加出库库存信息
                foreach (var outSku in outSkuList)
                {
                    outSku.OutId = outId;
                    // 添加
                    await _outDao.AddOutSku(OutSkuModelToEntityNoId(outSku), transaction);
                    // 修改具体位置库存数量
                    await _outDao.UpdateAddressSkuNumByAddressId(outSku, transaction);
                    // 修改库存总数量
                    await _skuDao.UpdateSkuTotalCount(outSku.SkuId, transaction);
                    addressIdSet.Add(outSku.AddressId);
                }
                return outId;
            });

            // 查看库存报警
            CheckAlarm(addressIdSet);
            return outId1;
        }

        /// <summary>
        /// 查看是否要报警
        /// </summary>
        /// <returns></returns>
        public async Task CheckAlarm(IEnumerable<string> addressIdSet)
        {
            Dictionary<string, SkuModel> map = new Dictionary<string, SkuModel>();
            foreach(var AddressId in addressIdSet)
            {
                SkuModel sku = await _skuDao.GetSkuByAddressId(AddressId);
                if (!map.ContainsKey(sku.Id))
                {
                    map.Add(sku.Id, sku);
                }
            }
            foreach (var item in map.Values)
            {
                if (item.TotalCount <= item.Alarm)
                {
                    // 报警操作

                }
            }
        }
        /// <summary>
        /// 更新整个出库单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Update(OutUpdateModel model)
        {
            // 子项查重
            IEnumerable<OutSkuAddModel> outSkuList = model.outSkuList;
            IsRepeatAndThrowException(outSkuList);
            // 获取数量变化的Address sku
            IEnumerable<OutSkuAddModel> outSkuList2 = await GetChangeAddressSku(outSkuList, model.Id);
            // 记录出库关联的AddressId
            HashSet<string> addressIdSet = new HashSet<string>();
            bool res2 =  await _outDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 3. 更新
                bool res = await _outDao.UpdateOut(model, transaction);
                // 添加盘点库存信息
                if (res)
                {
                    // 1. 删除子项
                    await _outDao.DeleteOutSkuByOutId(model.Id, transaction);
                    // 添加入库库存
                    foreach (var item in outSkuList)
                    {
                        item.OutId = model.Id;
                        await _outDao.AddOutSku(OutSkuModelToEntityNoId(item), transaction);
                        addressIdSet.Add(item.AddressId);
                    }
                    // 修改具体位置的库存数量
                    foreach (var outSku in outSkuList2)
                    {
                        // 修改具体位置库存数量
                        await _outDao.UpdateAddressSkuNumByAddressId(outSku, transaction);
                        // 修改库存总数量
                        await _skuDao.UpdateSkuTotalCountByAddressId(outSku.AddressId, transaction);
                        addressIdSet.Add(outSku.AddressId);
                    }
                }
                return res;
            });
            // 查看库存报警
            CheckAlarm(addressIdSet);
            return res2;
        }
        /// <summary>
        /// 获取需要更新数量的OutSku -- Address -sku
        /// </summary>
        /// <param name="outSkuList">现在更新的列表</param>
        /// <param name="OutId">出库单ID</param>
        /// <returns></returns>
        public async Task<IEnumerable<OutSkuAddModel>> GetChangeAddressSku(IEnumerable<OutSkuAddModel> outSkuList, string OutId)
        {
            // 获取原来的子项，以便下面修改库存数量变化
            IEnumerable<SkuEntryOrOutModel> skuList = await _outDao.GetListOutSkuByOutId(OutId);
            Dictionary<string, SkuEntryOrOutModel> outSkuMap1 = new Dictionary<string, SkuEntryOrOutModel>();
            Dictionary<string, OutSkuAddModel> outSkuMap2 = new Dictionary<string, OutSkuAddModel>();
            // 记录要修改的具体位置库存 addressId -- quantity 出库（-）
            List<OutSkuAddModel> outSkuList2 = new List<OutSkuAddModel>();
            foreach (var item in skuList)
            {
                if (!outSkuMap1.ContainsKey(item.AddressId))
                {
                    outSkuMap1.Add(item.AddressId, item);
                }
            }
            // 计算具体位置库存数量变化
            foreach (var item in outSkuList)
            {
                if (outSkuMap1.ContainsKey(item.AddressId))   // 原来添加列表中存在现在添加的库存
                {
                    OutSkuAddModel eSku = new OutSkuAddModel();
                    SkuEntryOrOutModel sku = new SkuEntryOrOutModel();
                    outSkuMap1.TryGetValue(item.AddressId, out sku);
                    int value = item.Quantity - sku.TotalCount; // 变小(原来减多了)，- 负值，变大，- 差值
                    eSku.Quantity = value;
                    if (value != 0)  // 为0库存数量不做变化
                    {
                        eSku.AddressId = sku.AddressId;
                        outSkuList2.Add(eSku);
                    }
                }
                else // 原来列表不存在这个添加数据
                {
                    outSkuList2.Add(item);
                }
                // 原来列表存在，现在没有的, 先记录map后比较
                outSkuMap2.Add(item.AddressId, item);
            }
            foreach (var item in skuList)
            {
                // 原来列表存在，现在没有的
                if (!outSkuMap2.ContainsKey(item.AddressId))
                {
                    OutSkuAddModel eSku = new OutSkuAddModel();
                    eSku.AddressId = item.AddressId;
                    eSku.Quantity = -1 * item.TotalCount;   // 减回来
                    outSkuList2.Add(eSku);
                }
            }
            return outSkuList2;
        }
        /// <summary>
        /// 查重
        /// </summary>
        public void IsRepeatAndThrowException(IEnumerable<OutSkuAddModel> outSkuList)
        {
            List<OutSkuAddModel> list = outSkuList.Distinct(new OutSkuModelComparer()).ToList();
            if (outSkuList.Count() != list.Count())
            {
                throw new MyServiceException(MsgCode.SameData, "存在相同数据");
            }
        }

        public async Task<IEnumerable<OutModel>> GetAll()
        {
            // 1. 获取 EntryList
            IEnumerable<OutModel> outList = await _outDao.GetAll();
            // 2. 获取 EntrySku
            foreach (var item in outList)
            {
                item.skuList = await _outDao.GetListOutSkuByOutId(item.Id);
            }
            return outList;
        }

        public async Task<OutListWithPagingModel> GetListPageBySearch(OutPageSearchModel model)
        {
            // 获取EntryList
            OutListWithPagingModel pageModel = await _outDao.GetOutPageBySearch(model);
            // 获取EntrySku
            foreach (var item in pageModel.Items)
            {
                item.skuList = await _outDao.GetListOutSkuByOutId(item.Id);
                // 获取规格
                foreach(var sku in item.skuList)
                {
                    sku.attrList = await _skuDao.SelectAttrBySkuId(sku.SkuId);
                    // 获取位置信息
                    sku.AddressModel = await _skuDao.SelectAddressByAddressId(sku.AddressId);
                }

            }
            return pageModel;
        }

        public async Task<bool> UpdateDescription(string outId, string description)
        {
            return await _outDao.UpdateDescriptionByOutId(outId, description);
        }
        public SMS_OUT_SKU OutSkuModelToEntityNoId(OutSkuAddModel model)
        {
            return new SMS_OUT_SKU
            {
                OUT_ID = model?.OutId,
                SKU_ID = model?.SkuId,
                QUANTITY = (int)model?.Quantity,
                PRICE = (decimal)model?.Price,
                ADDRESS_ID = model?.AddressId,
                TOTAL_PRICE = (decimal)model?.TotalPrice,
                TOOL = (int)model?.Tool
            };
        }
        /// <summary>
        /// 将model 转换为表 entity，没有ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SMS_OUT ModelToEntityNoId(OutAddModel model = null)
        {
            return new SMS_OUT
            {
                OUT_NO = model?.OutNo,
                OPERATOR = model?.Operator,
                DESCRIPTION = model?.Description,
                TOTAL_PRICE = (decimal)model?.TotalPrice,
                OUT_DATE = (DateTime)model?.OutDate,
                BATCH = (int)model?.Batch,
                CLIENT_ID = model?.ClientId
            };
        }
        /// <summary>
        /// 将model 转换为表 entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SMS_OUT ModelToEntity(OutModel model)
        {
            SMS_OUT entity = ModelToEntityNoId(model);
            entity.ID = model.Id;
            return entity;
        }
    }
    /// <summary>
    ///  OutSkuModel 去重比较器
    /// </summary>
    public class OutSkuModelComparer : IEqualityComparer<OutSkuAddModel>
    {
        public bool Equals(OutSkuAddModel x, OutSkuAddModel y)
        {
            //这里定义比较的逻辑
            return x.SkuId == y.SkuId && x.Status == y.Status && x.AddressId == y.AddressId && x.Tool == y.Tool;
        }

        public int GetHashCode(OutSkuAddModel obj)
        {
            //返回字段的HashCode，只有HashCode相同才会去比较
            return (obj.SkuId + obj.Status + obj.AddressId + obj.Tool).GetHashCode();
        }
    }
}
