using DapperExtensions;
using DataModel;
using DataModel.System;
using DateModel;
using DateModel.Client;
using Entity;
using Interface;
using Interface.Client;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Client;

namespace DAO.Client
{
    public class ClientDao : BaseDAO, IClientRepository
    {
        public ClientDao() : base() { }

        public ClientDao(IDataRepository repository) : base(repository) { }

        public async Task<string> InsertAsync(CMS_CLIENT application, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync(application, transaction);
        }

        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }

        public async Task<bool> DeleteAsync(string id, IDbTransaction transaction = null)
        {
            var predicate = Predicates.Field<CMS_CLIENT>(exp => exp.ID, Operator.Eq, id);
            return await Repository.DeleteAsync<CMS_CLIENT>(predicate, transaction) > 0 ? true : false;
        }

        public async Task<bool> EditAsync(CMS_CLIENT application, IDbTransaction transaction = null)
        {
            return await Repository.UpdateAsync(application, transaction);  // 字段全部更新包括创建时间
        }

        public async Task<bool> EditAsync(Dictionary<string, object> setting, Dictionary<string, object> where, IDbTransaction transaction = null)
        {
            return await Repository.UpdateAsync<CMS_CLIENT>(setting, where, transaction);
        }

        public async Task<bool> EditAsyncBySQL(CMS_CLIENT data, IDbTransaction transaction = null)
        {
            string sql = @"UPDATE CMS_CLIENT
                            SET COMPANY = @Company,
	                            ADDRESS = @Address,
	                            PHONE = @Phone,
	                            CONTACT = @Contact,
	                            EMAIL = @Email,
	                            TYPE = @Type,
	                            DESCRIPTION = @Description,
                                LUD = @LUD
                            where ID = @id";
            var queryParams = new
            {
                Company = data?.COMPANY,
                Address = data?.ADDRESS,
                Phone = data?.PHONE,
                Contact = data?.CONTACT,
                Email = data?.EMAIL,
                Type = data?.TYPE,
                Description = data?.DESCRIPTION,
                LUD = data?.LUD,
                id = data?.ID
            };
            return await Repository.ExecuteAsync(sql, queryParams) > 0 ? true : false;
        }

        public async Task<ClientListWithPagingViewModel> GetClientGroupWithPaging(BaseSearchModel searchModel)
        {
            ClientListWithPagingViewModel viewModel = new ClientListWithPagingViewModel();
            viewModel.TotalCount = await GetCountAsync(searchModel);
            if (viewModel.TotalCount <= 0)
            {
                return viewModel;
            }
            viewModel.Items = await BuildViewModelItems(searchModel);
            return viewModel;
        }

        private async Task<IEnumerable<ClientViewModel>> BuildViewModelItems(BaseSearchModel searchModel)
        {
            var predicateGroup = Predicates.Group(GroupOperator.And);
            predicateGroup.Predicates = new List<IPredicate>();
            //if (!string.IsNullOrEmpty(searchModel?.PageIndex + ""))
            //{
            //    var predicateLikeAccount = Predicates.Field<CMS_CLIENT>(exp => exp.ACCOUNT, Operator.Like, "%" + searchModel.Account + "%");
            //    predicateGroup.Predicates.Add(predicateLikeAccount);
            //}
            var predicateSort = Predicates.Sort<CMS_CLIENT>(exp => exp.ID);
            //IEnumerable<ClientViewModel> roomGroup = await Repository.GetPageListAsync<CMS_CLIENT>(searchModel.PageIndex, searchModel.PageSize, predicateGroup, new[] { predicateSort }) as IEnumerable<ClientViewModel>;
            var roomGroup = await Repository.GetPageListAsync<CMS_CLIENT>(searchModel.PageIndex, searchModel.PageSize, predicateGroup, new[] { predicateSort });
            List<ClientViewModel> list = new List<ClientViewModel>();
            if (roomGroup == null)
            {
                return list;
            }
            else
            {
                foreach (var c in roomGroup)
                {
                    list.Add(TableEntityToViewModel(c));
                }
            }
            return list;
        }

        public ClientViewModel TableEntityToViewModel(CMS_CLIENT entity)
        {
            if (entity == null)
            {
                return new ClientViewModel();
            }
            else
            {
                return new ClientViewModel
                {
                    id = entity?.ID,
                    Company = entity?.COMPANY,
                    Address = entity?.ADDRESS,
                    Description = entity?.DESCRIPTION,
                    Email = entity?.EMAIL,
                    Phone = entity?.PHONE,
                    Type = entity?.TYPE
                };
            }
        }

        public async Task<int> GetCountAsync(BaseSearchModel searchModel)
        {
            //UserSearchModel searchCondition = model as UserSearchModel;
            var predicateGroup = Predicates.Group(GroupOperator.And);
            predicateGroup.Predicates = new List<IPredicate>();
            //if (!string.IsNullOrEmpty(searchModel?.Account))
            //{
            //    var predicateLikeAccount = Predicates.Field<T_SYSTEM_USER>(exp => exp.ACCOUNT, Operator.Like, "%" + searchCondition.Account + "%");
            //    predicateGroup.Predicates.Add(predicateLikeAccount);
            //}
            return await Repository.CountAsync<CMS_CLIENT>(predicateGroup);
        }

        public async Task<IEnumerable<CMS_CLIENT>> GetGroupAsync()
        {
            return await Repository.GetListAsync<CMS_CLIENT>();
        }

        public async Task<bool> IsExist(string company)
        {
            var predicateApplicationCode = Predicates.Field<CMS_CLIENT>(exp => exp.COMPANY, Operator.Eq, company);
            return await Repository.CountAsync<CMS_CLIENT>(predicateApplicationCode) > 0 ? true : false;
        }

    }
}
