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
    public class EntrySupervisor: BaseBLL, IEntrySupervisor
    {
        public IEntryRepository _entryDao;
        public EntrySupervisor(IEntryRepository entryDao)
        {
            _entryDao = InitDAO<EntryDao>(entryDao) as EntryDao;
        }

        public async Task<string> Add(EntryAddModel model)
        {
            // 1. 查重
            IEnumerable<EntrySkuModel> entrySkuList = model.entrySkuList;
            List<EntrySkuModel> list = entrySkuList.Distinct(new EntrySkuModelComparer()).ToList();
            if(entrySkuList.Count() == list.Count())
            {
                throw new MyServiceException(MsgCode.SameData, "存在相同数据");
            }
            // 2. 生成入库单号 入库时间(年月日 + 供应商 + 批次) ： 2019012200101
            model.EntryNo = string.Format("{0:yyyyMMdd}", model.EntryDate) + model.SupplierId.PadLeft(3, '0') + model.Batch.ToString().PadLeft(2,'0');
            // 3. 查是否存在
            bool exist = await _entryDao.IsExistByEntryNo(model.EntryNo);
            if (exist)
            {
                throw new MyServiceException(MsgCode.SameData, "该批次库存已经添加");
            }
            return await _entryDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 添加入库单
                string entryId = await _entryDao.Insert(ModelToEntityNoId(model), transaction);
                // 添加入库库存信息
                await _entryDao.AddEntrySku(model.entrySkuList, entryId, transaction);
                // 修改库存数量
                await _entryDao.UpdateSkuNum(model.entrySkuList, transaction);
                return entryId;
            });
        }

        public async Task<IEnumerable<EntryModel>> GetAll()
        {
            // 1. 获取 EntryList
            IEnumerable<EntryModel> entryList = await _entryDao.GetAll();
            // 2. 获取 EntrySku
            foreach(var entry in entryList)
            {
                entry.entrySkuList = await _entryDao.GetListEntrySkuByEntryId(entry.Id);
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
                entry.entrySkuList = await _entryDao.GetListEntrySkuByEntryId(entry.Id);
            }
            return pageModel;
        }

        public Task<bool> UpdateDescription(string entryId, string Description)
        {
            return _entryDao.UpdateDescriptionByEntryId(entryId, Description);
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
    public class EntrySkuModelComparer : IEqualityComparer<EntrySkuModel>
    {
        public bool Equals(EntrySkuModel x, EntrySkuModel y)
        {
            //这里定义比较的逻辑
            return x.SkuId == y.SkuId && x.Status == y.Status && x.AddressId == y.AddressId;
        }

        public int GetHashCode(EntrySkuModel obj)
        {
            //返回字段的HashCode，只有HashCode相同才会去比较
            return (obj.SkuId + obj.Status + obj.AddressId).GetHashCode();
        }
    }
}
