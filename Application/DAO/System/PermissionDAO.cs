using DapperExtensions;
using DataModel;
using DataModel.System;
using Entity;
using Entity.Sys;
using Interface;
using Interface.System;
using ORM;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DAO.System
{
    /// <summary>
    /// Author:Xavier
    /// CreateDate:2018-11-03
    /// </summary>
    public class PermissionDAO : BaseDAO, IPermissionDAO
    {
        public PermissionDAO() : base() { }

        public PermissionDAO(IDataRepository repository) : base(repository) { }

        public async Task<IEnumerable<T_SYSTEM_PERMISSION>> GetPermissionByRoleAsync(string roleCode)
        {
            string sql = @"SELECT * FROM t_system_permission WHERE code IN 
                                        (SELECT permission_code FROM t_system_role_permission WHERE role_code='{0}')";
            return await Repository.GetGroupAsync<T_SYSTEM_PERMISSION>(string.Format(sql, roleCode));
        }

        public async Task<IEnumerable<SearchPermissionModel>> GetAllAuthorityAsync()
        {
            string sql = @"SELECT code AS AuthorityCode,name AS AuthorityName,parent_code AS ParentCode,type AS AuthorityType FROM t_system_permission";
            return await Repository.GetGroupAsync<SearchPermissionModel>(sql);
        }

        public async Task<T_SYSTEM_PERMISSION> GetAsync(string permissionCode)
        {
            var predicate = Predicates.Field<T_SYSTEM_PERMISSION>(obj => obj.CODE, Operator.Eq, permissionCode);
            return await Repository.GetFirstAsync<T_SYSTEM_PERMISSION>(predicate);
        }

        public async Task<bool> DeleteAsync(string code, IDbTransaction transaction)
        {
            var predicateCode = Predicates.Field<T_SYSTEM_PERMISSION>(exp => exp.CODE, Operator.Eq, code);
            return await Repository.DeleteAsync<T_SYSTEM_PERMISSION>(predicateCode, transaction) > 0 ? true : false;
        }

        public async Task<IEnumerable<T>> GetPageAsync<T>(BaseSearchModel model, CurrentUserInfo userInfo = null, IAppendSqlSearchConditionProvider dataProvider = null) where T : BaseEntity
        {
            PermissionPageSearchModel searchCondition = model as PermissionPageSearchModel;
            var predicateSort = Predicates.Sort<T_SYSTEM_PERMISSION>(exp => exp.SORT_NUM);
            return await Repository.GetPageListAsync<T_SYSTEM_PERMISSION>(
                searchCondition.PageIndex,
                searchCondition.PageSize,
                BuildSearchPredicate(searchCondition.ParentCode),
                new[] { predicateSort }) as IEnumerable<T>;
        }

        public async Task<int> GetCount(BaseSearchModel model, CurrentUserInfo userInfo = null, IAppendSqlSearchConditionProvider dataProvider = null)
        {
            PermissionPageSearchModel searchCondition = model as PermissionPageSearchModel;
            return await Repository.CountAsync<T_SYSTEM_PERMISSION>(BuildSearchPredicate(searchCondition.ParentCode));
        }

        public async Task<T> GetEntityByIdAsync<T>(string id) where T : BaseEntity
        {
            return await Repository.GetByIdAsync<T_SYSTEM_PERMISSION>(id) as T;
        }

        public async Task<string> InsertAsync<T>(T entity, IDbTransaction transaction = null) where T : BaseEntity
        {
            return await Repository.InsertAsync(entity as T_SYSTEM_PERMISSION);
        }

        public async Task<bool> EditAsync(UpdateModel model, IDbTransaction transaction = null)
        {
            return await Repository.UpdateAsync<T_SYSTEM_PERMISSION>(model.SetCollection, model.WhereCollection, transaction);
        }

        private IPredicate BuildSearchPredicate(string parentCode)
        {
            return Predicates.Field<T_SYSTEM_PERMISSION>(exp => exp.PARENT_CODE, Operator.Eq, parentCode);
        }

        public async Task<IEnumerable<T_SYSTEM_PERMISSION>> GetAllAsync(string menuCode)
        {
            var predicateSort = Predicates.Sort<T_SYSTEM_PERMISSION>(exp => exp.SORT_NUM);
            return await Repository.GetListAsync<T_SYSTEM_PERMISSION>(BuildSearchPredicate(menuCode), new[] { predicateSort });
        }
    }
}
