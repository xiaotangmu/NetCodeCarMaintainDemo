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

        public async Task<string> Add(OutAddModel model)
        {
            // 1. 查重
            IEnumerable<OutSkuAddModel> outSkuList = model.outSkuList;
            List<OutSkuAddModel> list = outSkuList.Distinct(new OutSkuModelComparer()).ToList();
            if (outSkuList.Count() != list.Count())
            {
                throw new MyServiceException(MsgCode.SameData, "存在相同数据");
            }
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
            // 记录查询是否报警的skuId，方便最后查询
            HashSet<string> skuIdSet = new HashSet<string>();
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
                    await _outDao.AddOutSku(OutSkuModelToEntityNoId(outSku), outId, transaction);
                    // 修改具体位置库存数量
                    await _outDao.UpdateAddressSkuNumByAddressId(outSku, transaction);
                    // 修改库存总数量
                    await _skuDao.UpdateSkuTotalCount(outSku.SkuId, transaction);
                    skuIdSet.Add(outSku.SkuId);
                }
                return outId;
            });

            // 查看库存报警
            CheckAlarm(skuIdSet);
            return outId1;
        }

        /// <summary>
        /// 查看是否要报警
        /// </summary>
        /// <returns></returns>
        public async Task CheckAlarm(IEnumerable<string> skuIdSet)
        {
            foreach(var skuId in skuIdSet)
            {
                SkuModel sku = await _skuDao.GetSkuById(skuId);
                if(sku.TotalCount <= sku.Alarm)
                {
                    // 报警操作

                }
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
            }
            return pageModel;
        }

        public async Task<bool> UpdateDescription(string outId, string description)
        {
            return await _outDao.UpdateDescriptionByEntryId(outId, description);
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
