using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Sku;
using ViewModel.Common;

namespace Supervisor.Sku
{
    /// <summary>
    /// </summary>
    public interface ICheckSupervisor
    {
        Task<string> Add(CheckAddModel model);
        Task<bool> UpdateCheckSkuStatus(IEnumerable<CheckUpdateModel> modelList);
        Task<bool> UpdateAllStatus(CheckUpdateModel model);
        Task<IEnumerable<CheckModel>> GetAll();
        Task<PageModel<CheckModel>> GetListPageBySearch(CheckPageSearchModel model);
    }
}
