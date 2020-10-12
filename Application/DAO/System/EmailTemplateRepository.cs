using DapperExtensions;
using DateModel.System;
using Interface;
using Interface.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DAO.System
{
    public class EmailTemplateRepository : BaseDAO, IEmailTemplateRepository
    {
        public async Task<int> Count(T_EMAIL_TEMPLATE entity)
        {
            var predicate = BuildPredicateGroup(entity);
            return await Repository.CountAsync<T_EMAIL_TEMPLATE>(predicate);
        }

        private IPredicateGroup BuildPredicateGroup(T_EMAIL_TEMPLATE entity)
        {
            var predicateGroup = Predicates.Group(GroupOperator.And);
            predicateGroup.Predicates = new List<IPredicate>();
            if (!string.IsNullOrEmpty(entity.CODE))
            {
                var predicate = Predicates.Field<T_EMAIL_TEMPLATE>(exp => exp.CODE, Operator.Eq, entity.CODE);
                predicateGroup.Predicates.Add(predicate);
            }
            if (!string.IsNullOrEmpty(entity.NAME))
            {
                var predicate = Predicates.Field<T_EMAIL_TEMPLATE>(exp => exp.NAME, Operator.Like, "%" + entity.NAME + "%");
                predicateGroup.Predicates.Add(predicate);
            }
            return predicateGroup;
        }

        public async Task<bool> Delete(string templateCode, IDbTransaction transaction = null)
        {
            var predicateCode = Predicates.Field<T_EMAIL_TEMPLATE>(exp => exp.CODE, Operator.Eq, templateCode);
            return await Repository.DeleteAsync<T_EMAIL_TEMPLATE>(predicateCode, transaction) > 0 ? true : false;
        }

        public async Task<bool> Edit(Dictionary<string, object> setting, Dictionary<string, object> where, IDbTransaction transaction = null)
        {
            return await Repository.UpdateAsync<T_EMAIL_TEMPLATE>(setting, where, transaction);
        }

        public async Task<IEnumerable<T_EMAIL_TEMPLATE>> GetGroupWithPaging(T_EMAIL_TEMPLATE entity, int pageIndex, int pageSize)
        {
            var predicate = BuildPredicateGroup(entity);
            var sort = Predicates.Sort<T_EMAIL_TEMPLATE>(exp => exp.CODE);
            return await Repository.GetPageListAsync<T_EMAIL_TEMPLATE>(pageIndex, pageSize, predicate, new[] { sort });
        }

        public async Task<string> Insert(T_EMAIL_TEMPLATE entity, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync(entity);
        }
    }
}
