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
        Task AddEntrySku(IEnumerable<EntrySkuModel> entrySkuList, string entryId, IDbTransaction transaction);
        Task UpdateSkuNum(IEnumerable<EntrySkuModel> entrySkuList, IDbTransaction transaction);
        Task<IEnumerable<EntryModel>> GetAll();
        Task<IEnumerable<EntrySkuModel>> GetListEntrySkuByEntryId(string id);
        Task<EntryListWithPagingModel> GetEntryPageBySearch(EntryPageSearchModel model);
        Task<bool> UpdateDescriptionByEntryId(string entryId, string description);
    }
}
