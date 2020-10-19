using Dapper;
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
using System.Linq;
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

        /// <summary>
        /// 模糊查询company，分页
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<ClientListWithPagingViewModel> GetClientGroupWithPagingBySearch(ClientListSearchViewModel model)
        {
            ClientListWithPagingViewModel viewModel = new ClientListWithPagingViewModel();
            viewModel.TotalCount = await GetCountAsync(model);
            if (viewModel.TotalCount <= 0)
            {
                return viewModel;
            }
            viewModel.Items = await BuildViewModelItems(model);
            return viewModel;
        }

        /// <summary>
        /// 获取所有，分页
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<ClientListWithPagingViewModel> GetClientGroupWithPaging(BaseSearchModel searchModel)
        {
            ClientListWithPagingViewModel viewModel = new ClientListWithPagingViewModel();
            viewModel.TotalCount = await GetCountAsync(searchModel as ClientListSearchViewModel);
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
            var predicateSort = Predicates.Sort<CMS_CLIENT>(exp => exp.ID);
            //IEnumerable<ClientViewModel> roomGroup = await Repository.GetPageListAsync<CMS_CLIENT>(searchModel.PageIndex, searchModel.PageSize, predicateGroup, new[] { predicateSort }) as IEnumerable<ClientViewModel>;
            var roomGroup = await Repository.GetPageListAsync<CMS_CLIENT>(searchModel.PageIndex, searchModel.PageSize, predicateGroup, new[] { predicateSort });
            return EntitysToModels(roomGroup);
        }

        public async Task<int> GetCountAsync(ClientListSearchViewModel searchModel)
        {
            //UserSearchModel searchCondition = model as UserSearchModel;
            var predicateGroup = Predicates.Group(GroupOperator.And);
            predicateGroup.Predicates = new List<IPredicate>();
            if (!string.IsNullOrEmpty(searchModel?.SearchStr))
            {
                var predicateLikeAccount = Predicates.Field<CMS_CLIENT>(exp => exp.COMPANY, Operator.Like, "%" + searchModel.SearchStr + "%");
                predicateGroup.Predicates.Add(predicateLikeAccount);
            }
            return await Repository.CountAsync<CMS_CLIENT>(predicateGroup);
        }

        public async Task<IEnumerable<ClientViewModel>> GetAllAsync()
        {
            IEnumerable<CMS_CLIENT> datas = await Repository.GetListAsync<CMS_CLIENT>();
            return EntitysToModels(datas);
        }

        public async Task<bool> IsExist(string company)
        {
            var predicateApplicationCode = Predicates.Field<CMS_CLIENT>(exp => exp.COMPANY, Operator.Eq, company);
            return await Repository.CountAsync<CMS_CLIENT>(predicateApplicationCode) > 0 ? true : false;
        }
        /// <summary>
        /// 条件查询，不分页
        /// </summary>
        /// <param name="searchStr"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ClientViewModel>> GetClientGroupBySearch(string searchStr)
        {

            string sql = @"select * 
                            from CMS_CLIENT
                            where COMPANY like '%' + @Company + '%'";
            IEnumerable<CMS_CLIENT> datas = (await Repository.GetGroupAsync<CMS_CLIENT>(sql, new { Company = searchStr }));
            return EntitysToModels(datas);
        }

        public ClientViewModel TableEntityToModel(CMS_CLIENT entity)
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
        public IEnumerable<ClientViewModel> EntitysToModels(IEnumerable<CMS_CLIENT> entityList)
        {
            List<ClientViewModel> list = new List<ClientViewModel>();
            if (entityList == null || entityList.Count() == 0)
            {
                return list;
            }
            foreach (var c in entityList)
            {
                list.Add(TableEntityToModel(c));
            }
            return list;
        }

    }
}
