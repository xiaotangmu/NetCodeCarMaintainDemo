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
    public interface IClientRepository : IBaseRepository
    {
        Task<string> InsertAsync(CMS_CLIENT application, IDbTransaction transaction = null);

        Task<bool> EditAsync(Dictionary<string, object> setting, Dictionary<string, object> where, IDbTransaction transaction = null);

        Task<bool> EditAsync(CMS_CLIENT application, IDbTransaction transaction = null);

        Task<bool> EditAsyncBySQL(CMS_CLIENT data, IDbTransaction transaction = null);

        Task<bool> DeleteAsync(string id, IDbTransaction transaction = null);

        Task<IEnumerable<CMS_CLIENT>> GetGroupAsync();

        Task<bool> IsExist(string company);

        Task<ClientListWithPagingViewModel> GetClientGroupWithPaging(ClientListSearchViewModel viewModel);

        Task<int> GetCountAsync(ClientListSearchViewModel searchModel);
    }
}
