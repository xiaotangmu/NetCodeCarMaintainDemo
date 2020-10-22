using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Sku;

namespace Supervisor.Sku
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOutSupervisor
    {
        Task<OutListWithPagingModel> GetListPageBySearch(OutPageSearchModel model);
        Task<IEnumerable<OutModel>> GetAll();
        Task<bool> UpdateDescription(string outId, string description);
        Task<string> Add(OutAddModel model);
    }
}
