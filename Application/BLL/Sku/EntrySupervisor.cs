using DAO.Sku;
using DateModel.Sku;
using Interface.Sku;
using NPOI.SS.Formula.Functions;
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
    public class EntrySupervisor: BaseBLL, IEntrySupervisor
    {
        public IEntryRepository _entryDao;
        public ISkuRepository _skuDao;
        public EntrySupervisor(IEntryRepository entryDao = null, ISkuRepository skuDao = null)
        {
            _entryDao = InitDAO<EntryDao>(entryDao) as EntryDao;
            _skuDao = new SkuDao(_entryDao.Repository);
        }

        public async Task<bool> Delete(string Id)
        {
            return await _entryDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 1. 删除关联Sku
                await _entryDao.DeleteEntrySkuByEntryId(Id, transaction);
                // 2. 删除entry
                return await _entryDao.DeleteEntryById(Id, transaction);
            });
        }
        public async Task<bool> DeleteBatch(IEnumerable<EntryDeleteModel> modelList)
        {
            return await _entryDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                foreach (var model in modelList)
                {
                    if (string.IsNullOrWhiteSpace(model.Id))
                    {
                        throw new MyServiceException("数据异常");
                    }
                    await _entryDao.DeleteEntrySkuByEntryId(model.Id, transaction);
                    await _entryDao.DeleteEntryById(model.Id, transaction);
                }
                return true;
            });
        }

        public async Task<string> Add(EntryAddModel model)
        {
            // 1. 查重
            IEnumerable<EntrySkuAddModel> entrySkuList = model.entrySkuList;
            IsRepeatAndThrowException(entrySkuList);
            // 2. 生成入库单号 入库时间(年月日 + 供应商 + 批次) ： 2019012200101
            //model.EntryNo = string.Format("{0:yyyyMMdd}", model.EntryDate) + model.SupplierId.PadLeft(3, '0') + model.Batch.ToString().PadLeft(2,'0');
            // 3. 查是否存在
            bool exist = await _entryDao.IsExistByEntryNo(model.EntryNo);
            if (exist)
            {
                throw new MyServiceException(MsgCode.SameData, "该批次库存已经添加");
            }
            return await _entryDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                decimal Total = 0;
                // 判断金额是否正确
                foreach (var entrySku in entrySkuList)
                {
                    entrySku.TotalPrice = entrySku.Quantity * entrySku.Price;
                    Total += entrySku.TotalPrice;
                }
                if(model.TotalPrice != Total)
                {
                    throw new MyServiceException("总金额不对");
                }
                // 添加入库单
                string entryId = await _entryDao.Insert(ModelToEntityNoId(model), transaction);
                // 添加入库库存信息
                foreach(var entrySku in entrySkuList)
                {
                    entrySku.EntryId = entryId;
                    await _entryDao.AddEntrySku(EntrySkuModelToEntityNoId(entrySku), entryId, transaction);
                    // 修改具体位置库存数量
                    await _entryDao.UpdateAddressSkuNumByAddressId(entrySku, transaction);
                    // 修改库存总数量
                    await _skuDao.UpdateSkuTotalCount(entrySku.SkuId, transaction);
                }
                
                return entryId;
            });
        }
        /// <summary>
        /// 更新整个入库单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Update(EntryUpdateModel model)
        {
            // 子项查重
            IEnumerable<EntrySkuAddModel> entrySkuList = model.entrySkuList;
            IsRepeatAndThrowException(entrySkuList);
            // 获取原来的子项，以便下面修改库存数量变化
            IEnumerable<SkuModel> skuList = await _entryDao.GetListEntrySkuByEntryId(model.Id);
            Dictionary<string, SkuModel> entrySkuMap1 = new Dictionary<string, SkuModel>();
            Dictionary<string, EntrySkuAddModel> entrySkuMap2 = new Dictionary<string, EntrySkuAddModel>();
            // 记录要修改的具体位置库存 addressId -- quantity 入库（+）
            List<EntrySkuAddModel> entrySkuList2 = new List<EntrySkuAddModel>();
            foreach(var item in skuList)
            {
                entrySkuMap1.Add(item.AddressId, item);
            }
            // 计算具体位置库存数量变化
            foreach(var item in entrySkuList)
            {
                if (entrySkuMap1.ContainsKey(item.AddressId))   // 原来添加列表中存在现在添加的库存
                {
                    EntrySkuAddModel eSku = new EntrySkuAddModel();
                    SkuModel sku = new SkuModel();
                    entrySkuMap1.TryGetValue(item.AddressId, out sku);
                    int value = item.Quantity - sku.TotalCount; // 变小，+ 负值，变大，+ 差值
                    eSku.Quantity = value;
                    if(value != 0)  // 为0库存数量不做变化
                    {
                        entrySkuList2.Add(eSku);
                    }
                }
                else // 原来列表不存在这个添加数据
                {
                    entrySkuList2.Add(item);
                }
                // 原来列表存在，现在没有的, 先记录map后比较
                entrySkuMap2.Add(item.AddressId, item);
            }
            foreach(var item in skuList)
            {
                // 原来列表存在，现在没有的
                if (!entrySkuMap2.ContainsKey(item.AddressId))
                {
                    EntrySkuAddModel eSku = new EntrySkuAddModel();
                    eSku.SkuId = item.
                    eSku.AddressId = item.AddressId;
                    eSku.Quantity = -1 * item.TotalCount;   // 减回来
                    entrySkuList2.Add(eSku);
                }
            }



            return await _entryDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 1. 删除子项
                await _entryDao.DeleteEntrySkuByEntryId(model.Id, transaction);

                // 3. 更新
                bool res = await _entryDao.UpdateEntry(model, transaction);
                // 添加盘点库存信息
                if (res)
                {
                    // 添加入库库存
                    foreach (var item in entrySkuList)
                    {
                        await _entryDao.AddEntrySku(EntrySkuModelToEntityNoId(item), model.Id, transaction);
                    }
                    // 修改具体位置的库存数量
                    foreach (var entrySku in entrySkuList2)
                    {
                        // 修改具体位置库存数量
                        await _entryDao.UpdateAddressSkuNumByAddressId(entrySku, transaction);
                        // 修改库存总数量
                        await _skuDao.UpdateSkuTotalCountByAddressId(entrySku.AddressId, transaction);
                    }
                }
                return res;
            });
        }
        /// <summary>
        /// 查重
        /// </summary>
        public void IsRepeatAndThrowException(IEnumerable<EntrySkuAddModel> entrySkuList)
        {
            List<EntrySkuAddModel> list = entrySkuList.Distinct(new EntrySkuModelComparer()).ToList();
            if (entrySkuList.Count() != list.Count())
            {
                throw new MyServiceException(MsgCode.SameData, "存在相同数据");
            }
        }

        public async Task<IEnumerable<EntryModel>> GetAll()
        {
            // 1. 获取 EntryList
            IEnumerable<EntryModel> entryList = await _entryDao.GetAll();
            // 2. 获取 EntrySku
            foreach(var entry in entryList)
            {
                entry.skuList = await _entryDao.GetListEntrySkuByEntryId(entry.Id);
            }
            return entryList;
        }

        public async Task<EntryListWithPagingModel> GetListPageBySearch(EntryPageSearchModel model)
        {
            // 获取EntryList
            EntryListWithPagingModel pageModel = await _entryDao.GetEntryPageBySearch(model);
            // 获取EntrySku
            foreach(var entry in pageModel.Items)
            {
                entry.skuList = await _entryDao.GetListEntrySkuByEntryId(entry.Id);
            }
            return pageModel;
        }

        public async Task<bool> UpdateDescription(string entryId, string Description)
        {
            return await _entryDao.UpdateDescriptionByEntryId(entryId, Description);
        }

        public SMS_ENTRY_SKU EntrySkuModelToEntityNoId(EntrySkuAddModel model)
        {
            return new SMS_ENTRY_SKU
            {
                ENTRY_ID = model?.EntryId,
                SKU_ID = model?.SkuId,
                QUANTITY = (int)model?.Quantity,
                PRICE = (decimal)model?.Price,
                ADDRESS_ID = model?.AddressId,
                TOTAL_PRICE = (decimal)model?.TotalPrice,
                STATUS = (int)model?.Status,
                OLD_PARTID = model?.OldPartId
            };
        }
        /// <summary>
        /// 将model 转换为表 entity，没有ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SMS_ENTRY ModelToEntityNoId(EntryAddModel model = null)
        {
            return new SMS_ENTRY
            {
                ENTRY_NO = model?.EntryNo,
                OPERATOR = model?.Operator,
                DESCRIPTION = model?.Description,
                TOTAL_PRICE = (decimal)model?.TotalPrice,
                ENTRY_DATE = (DateTime)model?.EntryDate,
                BATCH = (int)model?.Batch,
                SUPPLIER_ID = model?.SupplierId
            };
        }
        /// <summary>
        /// 将model 转换为表 entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SMS_ENTRY ModelToEntity(EntryModel model)
        {
            SMS_ENTRY entity = ModelToEntityNoId(model);
            entity.ID = model.Id;
            return entity;
        }
    }
    
    /// <summary>
    ///  EntrySkuModel 去重比较器
    /// </summary>
    public class EntrySkuModelComparer : IEqualityComparer<EntrySkuAddModel>
    {
        public bool Equals(EntrySkuAddModel x, EntrySkuAddModel y)
        {
            //这里定义比较的逻辑
            return x.SkuId == y.SkuId && x.Status == y.Status && x.AddressId == y.AddressId;
        }

        public int GetHashCode(EntrySkuAddModel obj)
        {
            //返回字段的HashCode，只有HashCode相同才会去比较
            return (obj.SkuId + obj.Status + obj.AddressId).GetHashCode();
        }
    }
}
