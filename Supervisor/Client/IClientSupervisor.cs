
using DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Client;

namespace Supervisor.Client
{
    /// <summary>
    /// </summary>
    public interface IClientSupervisor : IBaseSupervisor
    {
        Task<string> AddClient(ClientAddModel data);
        Task<bool> DeleteClient(string id);
        Task<bool> IsExitsClient(string company);
        Task<bool> UpdateClient(ClientViewModel model);
        Task<bool> UpdateClientBySQL(ClientViewModel model);
        Task<ClientListWithPagingViewModel> QueryPageAsync(BaseSearchModel model);
        Task<IEnumerable<ClientViewModel>> GetAll();
        Task<IEnumerable<ClientViewModel>> GetClientListBySearch(string searchStr);
        Task<ClientListWithPagingViewModel> GetClientListPageBySearch(ClientListSearchViewModel model);
    }
}
