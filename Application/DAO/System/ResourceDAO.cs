using DapperExtensions;
using DataAccess;
using DataModel;
using DataModel.System;
using Entity;
using Entity.Sys;
using Interface;
using Interface.System;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DAO.System
{
    public class ResourceDAO : BaseDAO, IResourceDAO
    {
        public ResourceDAO() : base() { }

        public ResourceDAO(IDataRepository repository) : base(repository) { }

        public async Task<IEnumerable<T_SYSTEM_RESOURCE>> GetAllAsync()
        {
            var predicateSort = Predicates.Sort<T_SYSTEM_RESOURCE>(exp => exp.SORT_NUM);
            return await Repository.GetPageListAsync<T_SYSTEM_RESOURCE>(-1, 10, null, new[] { predicateSort });
        }

        public async Task<T_SYSTEM_RESOURCE> GetAsync(string code)
        {
            var predicateCode = Predicates.Field<T_SYSTEM_RESOURCE>(exp => exp.CODE, Operator.Eq, code);
            return await Repository.GetFirstAsync<T_SYSTEM_RESOURCE>(predicateCode);
        }

        public async Task<bool> Delete(string code)
        {
            var predicateCode = Predicates.Field<T_SYSTEM_RESOURCE>(exp => exp.CODE, Operator.Eq, code);
            return await Repository.DeleteAsync<T_SYSTEM_RESOURCE>(predicateCode) > 0 ? true : false;
        }

        public async Task<IEnumerable<T_SYSTEM_RESOURCE>> GetByPermission(string permissionCode)
        {
            string sql = @"SELECT * FROM t_system_resource WHERE code IN (
                                        SELECT resource_code FROM t_system_permission_resource WHERE permission_code ='{0}')";
            return await Repository.GetGroupAsync<T_SYSTEM_RESOURCE>(string.Format(sql, permissionCode));
        }

        public async Task<IEnumerable<T_SYSTEM_RESOURCE>> GetPermissionMenus(string account)
        {
            string sqlResource = @"SELECT resource_code FROM t_system_permission_resource WHERE permission_code IN(
                                                        SELECT permission_code FROM t_system_role_permission WHERE role_code IN(
                                                                SELECT role_code FROM t_system_userrole WHERE 
                                                                    account IN (SELECT account FROM t_system_user WHERE account ='{0}' AND isuse = '1') 
                                                                    AND role_code IN (SELECT code FROM t_system_role WHERE isuse='1')
                                                                    ))";
            sqlResource = string.Format(sqlResource, account);
            string sql = @"SELECT * FROM t_system_resource WHERE type='1' AND code IN (
                                                        {0}
														UNION
														select  parent_code from t_system_resource where code IN ({0})
														) ORDER BY sort_num";
            return await Repository.GetGroupAsync<T_SYSTEM_RESOURCE>(string.Format(sql, sqlResource));
        }

        public async Task<IEnumerable<T>> GetPageAsync<T>(BaseSearchModel model, CurrentUserInfo userInfo = null, IAppendSqlSearchConditionProvider dataProvider = null) where T : BaseEntity
        {
            ResourceSearchConditionModel searchCondition = model as ResourceSearchConditionModel;
            var predicateGroup = Predicates.Group(GroupOperator.And);
            predicateGroup.Predicates = new List<IPredicate>();
            if (!string.IsNullOrEmpty(searchCondition.MenuCode))
            {
                var predicateParentCode = Predicates.Field<T_SYSTEM_RESOURCE>(exp => exp.PARENT_CODE, Operator.Eq, searchCondition.MenuCode);
                predicateGroup.Predicates.Add(predicateParentCode);
            }
            var predicateType = Predicates.Field<T_SYSTEM_RESOURCE>(exp => exp.TYPE, Operator.Eq, ((int)searchCondition.ResourceType).ToString());
            predicateGroup.Predicates.Add(predicateType);
            var predicateSort = Predicates.Sort<T_SYSTEM_RESOURCE>(exp => exp.SORT_NUM);
            return await Repository.GetPageListAsync<T_SYSTEM_RESOURCE>(searchCondition.PageIndex, searchCondition.PageSize, predicateGroup, new[] { predicateSort }) as IEnumerable<T>;
        }

        public async Task<int> GetCount(BaseSearchModel model, CurrentUserInfo userInfo = null, IAppendSqlSearchConditionProvider dataProvider = null)
        {
            ResourceSearchConditionModel searchCondition = model as ResourceSearchConditionModel;
            var predicateGroup = Predicates.Group(GroupOperator.And);
            predicateGroup.Predicates = new List<IPredicate>();
            if (!string.IsNullOrEmpty(searchCondition.MenuCode))
            {
                var predicateParentCode = Predicates.Field<T_SYSTEM_RESOURCE>(exp => exp.PARENT_CODE, Operator.Eq, searchCondition.MenuCode);
                predicateGroup.Predicates.Add(predicateParentCode);
            }
            var predicateType = Predicates.Field<T_SYSTEM_RESOURCE>(exp => exp.TYPE, Operator.Eq, ((int)searchCondition.ResourceType).ToString());
            predicateGroup.Predicates.Add(predicateType);
            return await Repository.CountAsync<T_SYSTEM_RESOURCE>(predicateGroup);
        }

        public async Task<T> GetEntityByIdAsync<T>(string id) where T : BaseEntity
        {
            return await Repository.GetByIdAsync<T_SYSTEM_RESOURCE>(id) as T;
        }

        public async Task<string> InsertAsync<T>(T entity, IDbTransaction transaction = null) where T : BaseEntity
        {
            return await Repository.InsertAsync(entity as T_SYSTEM_RESOURCE);
        }

        public async Task<bool> EditAsync(UpdateModel model, IDbTransaction transaction = null)
        {
            return await Repository.UpdateAsync<T_SYSTEM_RESOURCE>(model.SetCollection, model.WhereCollection, transaction);
        }

        public async Task<IEnumerable<T_SYSTEM_RESOURCE>> GetAllAsync(ResourceSearchConditionModel searchModel)
        {
            ResourceSearchConditionModel searchCondition = searchModel as ResourceSearchConditionModel;
            var predicateGroup = Predicates.Group(GroupOperator.And);
            predicateGroup.Predicates = new List<IPredicate>();
            if (!string.IsNullOrEmpty(searchCondition.MenuCode))
            {
                var predicateParentCode = Predicates.Field<T_SYSTEM_RESOURCE>(exp => exp.PARENT_CODE, Operator.Eq, searchCondition.MenuCode);
                predicateGroup.Predicates.Add(predicateParentCode);
            }
            var predicateType = Predicates.Field<T_SYSTEM_RESOURCE>(exp => exp.TYPE, Operator.Eq, ((int)searchCondition.ResourceType).ToString());
            predicateGroup.Predicates.Add(predicateType);
            var predicateSort = Predicates.Sort<T_SYSTEM_RESOURCE>(exp => exp.SORT_NUM);
            return await Repository.GetListAsync<T_SYSTEM_RESOURCE>(predicateGroup, new[] { predicateSort });
        }
    }
}
