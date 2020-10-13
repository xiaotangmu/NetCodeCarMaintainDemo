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
    public class UserDAO : BaseDAO, IUserRepository
    {
        public UserDAO() : base() { }

        public UserDAO(IDataRepository repository) : base(repository) { }

        public async Task<T_SYSTEM_USER> GetByLoginNameAsync(string account)
        {
            var predicate = Predicates.Field<T_SYSTEM_USER>(exp => exp.ACCOUNT, Operator.Eq, account.Trim());
            return await Repository.GetFirstAsync<T_SYSTEM_USER>(predicate);
        }

        public async Task<IEnumerable<T_SYSTEM_USER>> GetValidUserGroup()
        {
            var predicateIsUse = Predicates.Field<T_SYSTEM_USER>(user => user.ISUSE, Operator.Eq, ((int)Judge.YES).ToString());
            var predicateSort = Predicates.Sort<T_SYSTEM_USER>(user => user.OCD, true);
            return await Repository.GetListAsync<T_SYSTEM_USER>(predicateIsUse, new[] { predicateSort });
        }

        public async Task<bool> IsOpen(string account)
        {
            var predicateAccount = Predicates.Field<T_SYSTEM_USER>(exp => exp.ACCOUNT, Operator.Eq, account);
            var predicateIsUse = Predicates.Field<T_SYSTEM_USER>(exp => exp.ISUSE, Operator.Eq, ((int)Judge.YES).ToString());
            var predicateGroup = Predicates.Group(GroupOperator.And, predicateAccount, predicateIsUse);
            return (await Repository.CountAsync<T_SYSTEM_USER>(predicateGroup)) > 0;
        }

        public async Task<bool> IsExitsUser(string account)
        {
            var predicateCode = Predicates.Field<T_SYSTEM_USER>(obj => obj.ACCOUNT, Operator.Eq, account);
            return await Repository.CountAsync<T_SYSTEM_USER>(predicateCode) > 0 ? true : false;
        }

        public async Task<bool> DeleteAsync(string account)
        {
            var predicate = Predicates.Field<T_SYSTEM_USER>(exp => exp.ACCOUNT, Operator.Eq, account);
            return await Repository.DeleteAsync<T_SYSTEM_USER>(predicate) > 0 ? true : false;
        }

        public async Task<bool> AddUserRoleAsync(string account, string roleCode, IDbTransaction transaction = null)
        {
            T_SYSTEM_USERROLE entity = new T_SYSTEM_USERROLE();
            entity.ACCOUNT = account;
            entity.ROLE_CODE = roleCode;
            return !string.IsNullOrEmpty(await Repository.InsertAsync(entity, transaction));
        }

        public async Task<bool> DelUserRoleAsync(string account, IDbTransaction transaction = null)
        {
            string sql = @"DELETE FROM t_system_userrole WHERE account='{0}'";
            return await Repository.ExecuteAsync(string.Format(sql, account), null, transaction) >= 0 ? true : false;
        }

        public async Task<IEnumerable<T>> GetPageAsync<T>(BaseSearchModel model, CurrentUserInfo userInfo = null, IAppendSqlSearchConditionProvider dataProvider = null) where T : BaseEntity
        {
            UserSearchModel searchCondition = model as UserSearchModel;
            var predicateGroup = Predicates.Group(GroupOperator.And);
            predicateGroup.Predicates = new List<IPredicate>();
            if (!string.IsNullOrEmpty(searchCondition?.Account))
            {
                var predicateLikeAccount = Predicates.Field<T_SYSTEM_USER>(exp => exp.ACCOUNT, Operator.Like, "%" + searchCondition.Account + "%");
                predicateGroup.Predicates.Add(predicateLikeAccount);
            }
            var predicateSort = Predicates.Sort<T_SYSTEM_USER>(exp => exp.ACCOUNT);
            return await Repository.GetPageListAsync<T_SYSTEM_USER>(searchCondition.PageIndex, searchCondition.PageSize, predicateGroup, new[] { predicateSort }) as IEnumerable<T>;
        }

        public async Task<int> GetCount(BaseSearchModel model, CurrentUserInfo userInfo = null, IAppendSqlSearchConditionProvider dataProvider = null)
        {
            UserSearchModel searchCondition = model as UserSearchModel;
            var predicateGroup = Predicates.Group(GroupOperator.And);
            predicateGroup.Predicates = new List<IPredicate>();
            if (!string.IsNullOrEmpty(searchCondition?.Account))
            {
                var predicateLikeAccount = Predicates.Field<T_SYSTEM_USER>(exp => exp.ACCOUNT, Operator.Like, "%" + searchCondition.Account + "%");
                predicateGroup.Predicates.Add(predicateLikeAccount);
            }
            return await Repository.CountAsync<T_SYSTEM_USER>(predicateGroup);
        }

        public async Task<T> GetEntityByIdAsync<T>(string id) where T : BaseEntity
        {
            return await Repository.GetByIdAsync<T_SYSTEM_USER>(id) as T;
        }

        public async Task<string> InsertAsync<T>(T entity, IDbTransaction transaction = null) where T : BaseEntity
        {
            return await Repository.InsertAsync(entity as T_SYSTEM_USER, transaction);
        }

        public async Task<bool> EditAsync(UpdateModel model, IDbTransaction transaction = null)
        {
            return await Repository.UpdateAsync<T_SYSTEM_USER>(model.SetCollection, model.WhereCollection, transaction);
        }
    }
}
