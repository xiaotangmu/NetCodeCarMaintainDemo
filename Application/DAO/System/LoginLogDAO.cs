using DapperExtensions;
using DataModel;
using DataModel.System;
using Entity;
using Entity.Sys;
using Interface.System;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DAO.System
{
    public class LoginLogDAO : BaseDAO, ILoginLogDAO
    {
        public LoginLogDAO() : base() { }

        public LoginLogDAO(IDataRepository repository) : base(repository) { }

        public async Task<SYSTEM_LOGIN_LOG> GetLast(string name)
        {
            var predicateLoginUser = Predicates.Field<SYSTEM_LOGIN_LOG>(exp => exp.LOGIN_NAME, Operator.Eq, name);
            var predicateSort = Predicates.Sort<SYSTEM_LOGIN_LOG>(exp => exp.LOGIN_TIME, false);
            return await Repository.GetFirstAsync<SYSTEM_LOGIN_LOG>(predicateLoginUser, new[] { predicateSort });
        }

        public async Task<IEnumerable<T>> GetPageAsync<T>(BaseSearchModel model, CurrentUserInfo userInfo = null, IAppendSqlSearchConditionProvider dataProvider = null) where T : BaseEntity
        {
            var predicateSort = Predicates.Sort<SYSTEM_LOGIN_LOG>(exp => exp.LOGIN_TIME);
            return await Repository.GetPageListAsync<SYSTEM_LOGIN_LOG>(
                model.PageIndex,
                model.PageSize,
                BuildPredicate(model as LogSearchModel),
                new[] { predicateSort }) as IEnumerable<T>;
        }

        public async Task<int> GetCount(BaseSearchModel model, CurrentUserInfo userInfo = null, IAppendSqlSearchConditionProvider dataProvider = null)
        {
            return await Repository.CountAsync<SYSTEM_LOGIN_LOG>(BuildPredicate(model as LogSearchModel));
        }

        public async Task<T> GetEntityByIdAsync<T>(string id) where T : BaseEntity
        {
            return await Repository.GetByIdAsync<SYSTEM_LOGIN_LOG>(id) as T;
        }

        public async Task<string> InsertAsync<T>(T entity, IDbTransaction transaction = null) where T : BaseEntity
        {
            return await Repository.InsertAsync(entity as SYSTEM_LOGIN_LOG);
        }

        public Task<bool> EditAsync(UpdateModel model, IDbTransaction transaction = null)
        {
            return default;
        }

        private IPredicate BuildPredicate(LogSearchModel searchModel)
        {
            var predicateGroup = Predicates.Group(GroupOperator.And);
            predicateGroup.Predicates = new List<IPredicate>();
            if (!string.IsNullOrEmpty(searchModel.BeginTime))
            {
                var predicate = Predicates.Field<SYSTEM_LOGIN_LOG>(exp => exp.LOGIN_TIME, Operator.Ge, Convert.ToDateTime(searchModel.BeginTime));
                predicateGroup.Predicates.Add(predicate);
            }
            if (!string.IsNullOrEmpty(searchModel.EndTime))
            {
                var predicate = Predicates.Field<SYSTEM_LOGIN_LOG>(exp => exp.LOGIN_TIME, Operator.Le, Convert.ToDateTime(searchModel.EndTime));
                predicateGroup.Predicates.Add(predicate);
            }
            return predicateGroup;
        }

    }
}
