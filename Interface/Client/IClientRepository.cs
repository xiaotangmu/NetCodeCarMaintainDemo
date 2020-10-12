using DateModel;
using DateModel.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Client;

namespace Interface.Client
{
    public interface IClientRepository: IBaseRepository
    {
        Task<string> AddAsync(CMS_CLIENT application, IDbTransaction transaction = null);

        Task<bool> EditAsync(Dictionary<string, object> setting, Dictionary<string, object> where, IDbTransaction transaction = null);

        Task<bool> EditAsync(CMS_CLIENT application, IDbTransaction transaction = null);

        Task<bool> DeleteAsync(string addressCode, IDbTransaction transaction = null);

        Task<IEnumerable<CMS_CLIENT>> GetGroupAsync();

        Task<bool> IsExist(CMS_CLIENT application);

        Task<ClientListWithPagingViewModel> GetClientGroupWithPaging(ClientListSearchViewModel viewModel);

        Task<int> GetCountAsync(ClientListSearchViewModel searchModel);
    }
}
