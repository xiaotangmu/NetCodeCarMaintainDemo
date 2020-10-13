using DAO;
using DapperExtensions;
using DataModel;
using DataModel.System;
using Entity;
using Entity.Sys;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Interface.System
{
    /// <summary>
    /// Author:Xavier
    /// Create Date:2018-11-08
    /// </summary>
    public class RoleDAO : BaseDAO, IRoleDAO
    {
        public RoleDAO() : base() { }

        public RoleDAO(IDataRepository repository) : base(repository) { }

        public async Task<IEnumerable<T_SYSTEM_ROLE>> GetValidAsync()
        {
            var predicateIsUse = Predicates.Field<T_SYSTEM_ROLE>(exp => exp.ISUSE, Operator.Eq, ((int)Judge.YES).ToString());
            return await Repository.GetListAsync<T_SYSTEM_ROLE>(predicateIsUse);
        }

        public async Task<IEnumerable<T_SYSTEM_ROLE>> GetRolesByLoginName(string account)
        {
            string sql = string.Format(@"SELECT * FROM t_system_role where isuse='{0}' AND code IN 
                                                                (SELECT role_code FROM t_system_userrole WHERE account='{1}')", ((int)Judge.YES).ToString(), account);
            return await Repository.GetGroupAsync<T_SYSTEM_ROLE>(sql);
        }

        public async Task<T_SYSTEM_ROLE> GetAsync(string code)
        {
            var predicateCode = Predicates.Field<T_SYSTEM_ROLE>(obj => obj.CODE, Operator.Eq, code);
            T_SYSTEM_ROLE role = await Repository.GetFirstAsync<T_SYSTEM_ROLE>(predicateCode);
            if (role == null)
            {
                throw new Exception(await Localization.Localizer.GetValueAsync("角色不存在"));
            }
            return role;
        }

        public async Task<bool> EditAsync(UpdateModel update, IDbTransaction transaction = null)
        {
            return await Repository.UpdateAsync<T_SYSTEM_ROLE>(update.SetCollection, update.WhereCollection, transaction);
        }

        public async Task<bool> DeleteAsync(string code, IDbTransaction transaction = null)
        {
            var predicateCode = Predicates.Field<T_SYSTEM_ROLE>(obj => obj.CODE, Operator.Eq, code);
            return await Repository.DeleteAsync<T_SYSTEM_ROLE>(predicateCode, transaction) > 0 ? true : false;
        }

        public async Task<bool> IsUseRole(string code)
        {
            var predicateCode = Predicates.Field<T_SYSTEM_ROLE>(obj => obj.CODE, Operator.Eq, code);
            var predicateIsUse = Predicates.Field<T_SYSTEM_ROLE>(obj => obj.ISUSE, Operator.Eq, ((int)Judge.YES).ToString());
            var predicateGroup = Predicates.Group(GroupOperator.And, predicateCode, predicateIsUse);
            return await Repository.CountAsync<T_SYSTEM_ROLE>(predicateGroup) > 0 ? true : false;
        }

        public async Task<IEnumerable<T>> GetPageAsync<T>(BaseSearchModel model, CurrentUserInfo userInfo = null, IAppendSqlSearchConditionProvider dataProvider = null) where T : BaseEntity
        {
            var predicateSort = Predicates.Sort<T_SYSTEM_ROLE>(exp => exp.OCD);
            return await Repository.GetPageListAsync<T_SYSTEM_ROLE>(model.PageIndex, model.PageSize, null, new[] { predicateSort }) as IEnumerable<T>;
        }

        public async Task<int> GetCount(BaseSearchModel model, CurrentUserInfo userInfo = null, IAppendSqlSearchConditionProvider dataProvider = null)
        {
            return await Repository.CountAsync<T_SYSTEM_ROLE>(null);
        }

        public async Task<T> GetEntityByIdAsync<T>(string id) where T : BaseEntity
        {
            var predicate = Predicates.Field<T_SYSTEM_ROLE>(role => role.ID, Operator.Eq, id);
            return await Repository.GetFirstAsync<T_SYSTEM_ROLE>(predicate) as T;
        }

        public async Task<string> InsertAsync<T>(T entity, IDbTransaction transaction = null) where T : BaseEntity
        {
            return await Repository.InsertAsync(entity as T_SYSTEM_ROLE);
        }
    }
}
