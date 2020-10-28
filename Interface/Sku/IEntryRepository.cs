using DateModel.Sku;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Sku;

namespace Interface.Sku
{
    public interface IEntryRepository : IBaseRepository
    {
        Task<bool> IsExistByEntryNo(string entryNo);
        Task<string> Insert(SMS_ENTRY sMS_ENTRY, IDbTransaction transaction);
        Task<string> AddEntrySku(SMS_ENTRY_SKU entity, IDbTransaction transaction = null);
        Task<bool> UpdateAddressSkuNumByAddressId(EntrySkuAddModel model, IDbTransaction transaction);
        //Task<bool> UpdateSkuTotalCount(string SkuId, IDbTransaction transaction = null);
        Task<IEnumerable<EntryModel>> GetAll();
        Task<IEnumerable<SkuEntryOrOutModel>> GetListEntrySkuByEntryId(string id);
        Task<EntryListWithPagingModel> GetEntryPageBySearch(EntryPageSearchModel model);
        Task<bool> UpdateDescriptionByEntryId(string entryId, string description);
        Task<bool> DeleteEntrySkuByEntryId(string entryId, IDbTransaction transaction = null);
        Task<bool> DeleteEntryById(string Id, IDbTransaction transaction = null);
        Task<bool> UpdateEntry(EntryUpdateModel model, IDbTransaction transaction);
    }
}
