using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Sku;

namespace Supervisor.Sku
{
    /// <summary>
    /// </summary>
    public interface IEntrySupervisor
    {
        Task<string> Add(EntryAddModel model);
        Task<IEnumerable<EntryModel>> GetAll();
        Task<EntryListWithPagingModel> GetListPageBySearch(EntryPageSearchModel model);
        Task<bool> UpdateDescription(string entryId, string descriptions);
    }
}
