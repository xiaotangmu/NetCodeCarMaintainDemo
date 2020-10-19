using DAO;
using DAO.Client;
using DataModel;
using DateModel.Client;
using Interface;
using Interface.Client;
using Localization;
using Supervisor.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Client;

namespace BLL.Client
{
    public class ClientSupervisor : BaseBLL, IClientSupervisor
    {
        private IClientRepository _clientDAO;

        public ClientSupervisor(IClientRepository clientDao = null)
        {
            _clientDAO = InitDAO<ClientDao>(clientDao) as IClientRepository;
        }


        public async Task<string> AddClient(ClientAddModel data)
        {
            CMS_CLIENT client = ModelToTableEntity(data);
            string result = string.Empty;
            try
            {
                result = await _clientDAO.InsertAsync(client);
            }
            catch (Npgsql.PostgresException ex)
            {
                throw await ContrainExceptionFactory.Singleton.Create<CMS_CLIENT>(ex);
            }
            return result;
        }

        public async Task<bool> DeleteClient(string id)
        {
            return await _clientDAO.DeleteAsync(id);
        }

        public async Task<bool> IsExitsClient(string company)
        {
            await IfEmptyAndThrowException(company);
            return await _clientDAO.IsExist(company);
        }

        private async Task IfEmptyAndThrowException(string company)
        {
            if (company.Trim() == "")
            {
                throw new Exception(await Localizer.GetValueAsync("Company 字符串为空！"));
            }
        }

        public Task<ClientListWithPagingViewModel> QueryPageAsync(BaseSearchModel model)
        {
            return _clientDAO.GetClientGroupWithPaging(model);
        }

        /// <summary>
        /// 全部字段更新包括创建时间
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> UpdateClient(ClientViewModel data)
        {
            CMS_CLIENT client = ModelToTableEntity(data);
            client.ID = data.id;
            return await _clientDAO.EditAsync(client);
        }

        /// <summary>
        /// 没有创建时间
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> UpdateClientBySQL(ClientViewModel data)
        {
            CMS_CLIENT client = ModelToTableEntity(data);
            client.ID = data.id;
            return await _clientDAO.EditAsyncBySQL(client);
        }

        public CMS_CLIENT ModelToTableEntity(ClientAddModel data)
        {
            
            CMS_CLIENT client =  new CMS_CLIENT
            {
                COMPANY = data?.Company,
                ADDRESS = data?.Address,
                CONTACT = data?.Contact,
                PHONE = data?.Phone,
                EMAIL = data?.Email,
                TYPE = data?.Type,
                DESCRIPTION = data?.Description
            };

            return client;
        }

        /// <summary>
        /// 获取所有，不分页
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ClientViewModel>> GetAll()
        {
            return await _clientDAO.GetAllAsync();
        }

        /// <summary>
        /// 条件查询，不分页
        /// </summary>
        /// <param name="searchStr"></param>
        /// <returns></returns>
        public Task<IEnumerable<ClientViewModel>> GetClientListBySearch(string searchStr)
        {
            return _clientDAO.GetClientGroupBySearch(searchStr);
        }

        /// <summary>
        /// 条件查询，分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<ClientListWithPagingViewModel> GetClientListPageBySearch(ClientListSearchViewModel model)
        {
            return _clientDAO.GetClientGroupWithPagingBySearch(model);
        }
    }
}
