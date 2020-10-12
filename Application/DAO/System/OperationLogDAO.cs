using DapperExtensions;
using DataAccess;
using DataModel.System;
using Entity.Sys;
using ORM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.System
{
    public class OperationLogDAO : BaseDAO
    {
        public OperationLogDAO() : base() { }

        public OperationLogDAO(IDataRepository repository) : base(repository) { }

        public async Task<bool> InsertAsync(SYSTEM_OPERATION_LOG log)
        {
            return await Repository.InsertAsync(log) != null ? true : false;
        }

        public async Task<IEnumerable<SYSTEM_OPERATION_LOG>> GetAsync(LogSearchModel searchModel)
        {
            var predicateSort = Predicates.Sort<SYSTEM_OPERATION_LOG>(exp => exp.OPERATION_TIME);
            return await Repository.GetPageListAsync<SYSTEM_OPERATION_LOG>(searchModel.PageIndex, searchModel.PageSize, BuildPredicate(searchModel), new[] { predicateSort });
        }

        public async Task<int> GetCount(LogSearchModel searchModel)
        {
            return await Repository.CountAsync<SYSTEM_OPERATION_LOG>(BuildPredicate(searchModel));
        }

        private IPredicate BuildPredicate(LogSearchModel searchModel)
        {
            var predicateGroup = Predicates.Group(GroupOperator.And);
            predicateGroup.Predicates = new List<IPredicate>();
            if (!string.IsNullOrEmpty(searchModel.BeginTime))
            {
                var predicate = Predicates.Field<SYSTEM_OPERATION_LOG>(exp => exp.OPERATION_TIME, Operator.Ge, Convert.ToDateTime(searchModel.BeginTime));
                predicateGroup.Predicates.Add(predicate);
            }
            if (!string.IsNullOrEmpty(searchModel.EndTime))
            {
                var predicate = Predicates.Field<SYSTEM_OPERATION_LOG>(exp => exp.OPERATION_TIME, Operator.Le, Convert.ToDateTime(searchModel.EndTime));
                predicateGroup.Predicates.Add(predicate);
            }
            return predicateGroup;
        }
    }
}
