using DAO.Maintain;
using DAO.Sku;
using DateModel.Sku;
using Interface.Maintain;
using Interface.Sku;
using NPOI.OpenXmlFormats.Dml;
using NPOI.SS.Formula.Functions;
using Supervisor.Sku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.CustomException;
using ViewModel.Maintain;
using ViewModel.Sku;

namespace BLL.Sku
{
    public class EntrySupervisor: BaseBLL, IEntrySupervisor
    {
        public IEntryRepository _entryDao;
        public ISkuRepository _skuDao;
        public IMaintainRepository _maintainDao;
        public EntrySupervisor(IEntryRepository entryDao = null, ISkuRepository skuDao = null, IMaintainRepository maintainDao = null)
        {
            _entryDao = InitDAO<EntryDao>(entryDao) as EntryDao;
            _skuDao = new SkuDao(_entryDao.Repository);
            _maintainDao = new MaintainDao(_entryDao.Repository);
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
                    await _entryDao.AddEntrySku(EntrySkuModelToEntityNoId(entrySku), transaction);
                    if (entrySku.Status == 1) // 是旧配件
                    {
                        if (!string.IsNullOrWhiteSpace(entrySku.OldPartId))
                        {
                            // 更新旧配件表处理数量和入库状态 + 
                            await _entryDao.UpdateOldPartStatus(entrySku.OldPartId, entrySku.Quantity, transaction);
                        }
                        else
                        {
                            throw new MyServiceException("旧配件ID为空");
                        }
                    }  
                    if (entrySku.Status == 2)
                    {
                        if (!string.IsNullOrWhiteSpace(entrySku.ToolId))
                        {
                            // 更新工具表处理数量和入库状态 +
                            await _entryDao.UpdateToolStatus(entrySku.ToolId, entrySku.Quantity, transaction);
                        }
                        else
                        {
                            throw new MyServiceException("工具ID为空");
                        }
                    } 
                    
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
            // 获取数量变化的Address sku
            IEnumerable<EntrySkuAddModel> entrySkuList2 = await GetChangeEntrySku(entrySkuList, model.Id);
            return await _entryDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 3. 更新
                bool res = await _entryDao.UpdateEntry(model, transaction);
                // 添加盘点库存信息
                if (res)
                {
                    // 1. 删除子项
                    await _entryDao.DeleteEntrySkuByEntryId(model.Id, transaction);
                    // 添加入库库存
                    foreach (var item in entrySkuList)
                    {
                        item.EntryId = model.Id;
                        await _entryDao.AddEntrySku(EntrySkuModelToEntityNoId(item), transaction);
                        if (item.Status == 1) // 是旧配件
                        {
                            if (!string.IsNullOrWhiteSpace(item.OldPartId))
                            {
                                // 更新旧配件表处理数量和入库状态 + 
                                await _entryDao.UpdateOldPartStatus(item.OldPartId, item.Quantity, transaction);
                            }
                            else
                            {
                                throw new MyServiceException("旧配件ID为空");
                            }
                        }
                        if (item.Status == 2)
                        {
                            if (!string.IsNullOrWhiteSpace(item.ToolId))
                            {
                                // 更新工具表处理数量和入库状态 +
                                await _entryDao.UpdateToolStatus(item.ToolId, item.Quantity, transaction);
                            }
                            else
                            {
                                throw new MyServiceException("工具ID为空");
                            }
                        }
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
        /// 获取需要更新数量的EntrySku -- Address -sku
        /// </summary>
        /// <param name="entrySkuList">现在更新的列表</param>
        /// <param name="EntryId">入库单ID</param>
        /// <returns></returns>
        public async Task<IEnumerable<EntrySkuAddModel>> GetChangeEntrySku(IEnumerable<EntrySkuAddModel> entrySkuList, string EntryId)
        {
            // 获取原来的子项，以便下面修改库存数量变化
            IEnumerable<SkuEntryOrOutModel> skuList = await _entryDao.GetListEntrySkuByEntryId(EntryId);
            Dictionary<string, SkuEntryOrOutModel> entrySkuMap1 = new Dictionary<string, SkuEntryOrOutModel>();
            Dictionary<string, EntrySkuAddModel> entrySkuMap2 = new Dictionary<string, EntrySkuAddModel>();
            // 记录要修改的具体位置库存 addressId -- quantity 入库（+）
            List<EntrySkuAddModel> entrySkuList2 = new List<EntrySkuAddModel>();
            foreach (var item in skuList)
            {
                if (!entrySkuMap1.ContainsKey(item.AddressId)) 
                {
                    entrySkuMap1.Add(item.AddressId, item);
                }
                
            }
            // 计算具体位置库存数量变化
            foreach (var item in entrySkuList)
            {
                if (entrySkuMap1.ContainsKey(item.AddressId))   // 原来添加列表中存在现在添加的库存
                {
                    EntrySkuAddModel eSku = new EntrySkuAddModel();
                    SkuEntryOrOutModel sku = new SkuEntryOrOutModel();
                    entrySkuMap1.TryGetValue(item.AddressId, out sku);
                    int value = item.Quantity - sku.TotalCount; // 变小，+ 负值，变大，+ 差值
                    eSku.Quantity = value;
                    if (value != 0)  // 为0库存数量不做变化
                    {
                        eSku.AddressId = sku.AddressId;
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
            foreach (var item in skuList)
            {
                // 原来列表存在，现在没有的
                if (!entrySkuMap2.ContainsKey(item.AddressId))
                {
                    EntrySkuAddModel eSku = new EntrySkuAddModel();
                    eSku.AddressId = item.AddressId;
                    eSku.Quantity = -1 * item.TotalCount;   // 减回来
                    entrySkuList2.Add(eSku);
                }
            }
            return entrySkuList2;
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
            await GetSkuListReturnEntryList(entryList);
            // 3. 获取 维修单信息
            foreach(var item in entryList)
            {
                await GetMaintainEntryShowModel(item);
            }
            return entryList;
        }
        public async Task GetMaintainEntryShowModel(EntryModel item)
        {
            // 判断是否是为维修单入库
            if (item.IsMaintain == 1 && string.IsNullOrWhiteSpace(item.MaintainId))
            {
                // 获取维修单
                item.maintainShowModel = await _maintainDao.SelectMaintainInfoById(item.MaintainId);
            }
        }
        public async Task GetSkuListReturnEntryList(IEnumerable<EntryModel> modelList)
        {
            foreach (var entry in modelList)
            {
                await GetSkuList(entry);
            }
        }
        public async Task GetSkuList(EntryModel model)
        {
            model.skuList = await _entryDao.GetListEntrySkuByEntryId(model.Id);
            // 获取参数
            foreach (var sku in model.skuList)
            {
                sku.attrList = await _skuDao.SelectAttrBySkuId(sku.SkuId);
            }
        }

        public async Task<EntryListWithPagingModel> GetListPageBySearch(EntryPageSearchModel model)
        {
            // 获取EntryList
            EntryListWithPagingModel pageModel = await _entryDao.GetEntryPageBySearch(model);
            // 获取EntrySku
            await GetSkuListReturnEntryList(pageModel.Items);
            // 3. 获取 维修单信息
            foreach (var item in pageModel.Items)
            {
                await GetMaintainEntryShowModel(item);
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
                SUPPLIER_ID = model?.SupplierId,
                IS_MAINTAIN = (int)model?.IsMaintain,
                MAINTAIN_ID = model?.MaintainId
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
