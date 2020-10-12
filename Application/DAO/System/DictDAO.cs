using DAO;
using DapperExtensions;
using Entity;
using Entity.Sys;
using ORM;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Interface.System
{
    /// 数据字典持久层
    /// </summary>
    public class DictDAO : BaseDAO, IDictDAO
    {
        public DictDAO() : base() { }

        public DictDAO(IDataRepository repository) : base(repository) { }

        public async Task<IEnumerable<T_SYSTEM_DICT>> GetByTypeCodeAsync(string typeCode, string isUse)
        {
            var predicateForType = Predicates.Field<T_SYSTEM_DICT>(dict => dict.TYPE_CODE, Operator.Eq, typeCode);
            var predicateForIsUse = Predicates.Field<T_SYSTEM_DICT>(dict => dict.ISUSE, Operator.Eq, isUse);
            var predicateGroup = Predicates.Group(GroupOperator.And, predicateForType, predicateForIsUse);
            return await Repository.GetListAsync<T_SYSTEM_DICT>(predicateGroup);
        }

        public async Task<T_SYSTEM_DICT> GetDictData(string typeCode, string code)
        {
            var predicateForType = Predicates.Field<T_SYSTEM_DICT>(dict => dict.TYPE_CODE, Operator.Eq, typeCode);
            var predicateForCode = Predicates.Field<T_SYSTEM_DICT>(dict => dict.CODE, Operator.Eq, code);
            var predicateGroup = Predicates.Group(GroupOperator.And, predicateForType, predicateForCode);
            return await Repository.GetFirstAsync<T_SYSTEM_DICT>(predicateGroup);
        }

        public async Task<string> GetDictCode(string typeCode, string name)
        {
            var predicateForType = Predicates.Field<T_SYSTEM_DICT>(dict => dict.TYPE_CODE, Operator.Eq, typeCode);
            var predicateForCode = Predicates.Field<T_SYSTEM_DICT>(dict => dict.TEXT, Operator.Eq, name.Trim());
            var predicateGroup = Predicates.Group(GroupOperator.And, predicateForType, predicateForCode);
            var result = await Repository.GetFirstAsync<T_SYSTEM_DICT>(predicateGroup);
            if (result == null)
            {
                return string.Empty;
            }
            return result.CODE;
        }

        public async Task<bool> Delete(string code, string typeCode)
        {
            var predicateCode = Predicates.Field<T_SYSTEM_DICT>(exp => exp.CODE, Operator.Eq, code);
            var predicateType = Predicates.Field<T_SYSTEM_DICT>(exp => exp.TYPE_CODE, Operator.Eq, typeCode);
            var predicateGroup = Predicates.Group(GroupOperator.And, predicateCode, predicateType);
            return await Repository.DeleteAsync<T_SYSTEM_DICT>(predicateGroup) > 0 ? true : false;
        }

        public async Task<bool> Delete(string typeCode)
        {
            var predicateType = Predicates.Field<T_SYSTEM_DICT>(exp => exp.TYPE_CODE, Operator.Eq, typeCode);
            var predicateGroup = Predicates.Group(GroupOperator.And, predicateType);
            return await Repository.DeleteAsync<T_SYSTEM_DICT>(predicateGroup) > 0 ? true : false;
        }

        private IPredicate BuildSearchPredicate(T_SYSTEM_DICT searchModel)
        {
            var predicateGroup = Predicates.Group(GroupOperator.And);
            predicateGroup.Predicates = new List<IPredicate>();
            if (!string.IsNullOrEmpty(searchModel.TYPE_CODE))
            {
                var predicate = Predicates.Field<T_SYSTEM_DICT>(dict => dict.TYPE_CODE, Operator.Eq, searchModel.TYPE_CODE);
                predicateGroup.Predicates.Add(predicate);
            }
            if (!string.IsNullOrEmpty(searchModel.CODE))
            {
                var predicate = Predicates.Field<T_SYSTEM_DICT>(dict => dict.CODE, Operator.Like, "%" + searchModel.CODE + "%");
                predicateGroup.Predicates.Add(predicate);
            }
            if (!string.IsNullOrEmpty(searchModel.TEXT))
            {
                var predicate = Predicates.Field<T_SYSTEM_DICT>(dict => dict.TEXT, Operator.Like, "%" + searchModel.TEXT + "%");
                predicateGroup.Predicates.Add(predicate);
            }
            if (!string.IsNullOrEmpty(searchModel.ISUSE))
            {
                var predicate = Predicates.Field<T_SYSTEM_DICT>(dict => dict.ISUSE, Operator.Eq, searchModel.ISUSE);
                predicateGroup.Predicates.Add(predicate);
            }
            return predicateGroup;
        }

        public async Task<IEnumerable<T>> GetPageAsync<T>(T_SYSTEM_DICT model, int pageIndex, int pageSize)
        {
            var predicateSort = Predicates.Sort<T_SYSTEM_DICT>(exp => exp.SORT_NUMBER);
            return await Repository.GetPageListAsync<T_SYSTEM_DICT>(pageIndex, pageSize,
                BuildSearchPredicate(model), new[] { predicateSort }) as IEnumerable<T>;

        }

        public async Task<int> GetCount(T_SYSTEM_DICT model)
        {
            return await Repository.CountAsync<T_SYSTEM_DICT>(BuildSearchPredicate(model));
        }

        public async Task<T> GetEntityByIdAsync<T>(string id) where T : BaseEntity
        {
            return await Repository.GetByIdAsync<T_SYSTEM_DICT>(id) as T;
        }

        public async Task<string> InsertAsync<T>(T entity, IDbTransaction transaction = null) where T : BaseEntity
        {
            return await Repository.InsertAsync(entity as T_SYSTEM_DICT);
        }

        public async Task<bool> EditAsync(Dictionary<string, object> setting, Dictionary<string, object> where, IDbTransaction transaction = null)
        {
            return await Repository.UpdateAsync<T_SYSTEM_DICT>(setting, where);
        }

        public async Task<IEnumerable<T_SYSTEM_DICT>> GetAllAsync(T_SYSTEM_DICT searchCondition)
        {
            var predicateSort = Predicates.Sort<T_SYSTEM_DICT>(exp => exp.SORT_NUMBER);
            return await Repository.GetListAsync<T_SYSTEM_DICT>(BuildSearchPredicate(searchCondition), new[] { predicateSort });
        }
    }
}
