using DAO;
using DapperExtensions;
using Entity.Workflow;
using ORM;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Interface.Workflow
{
    public class AuditLogDAO : BaseDAO, IAuditLogDAO
    {
        public AuditLogDAO() : base() { }

        public AuditLogDAO(IDataRepository repository) : base(repository) { }

        public async Task<bool> DeleteAsync(string queueId, IDbTransaction transaction)
        {
            var predicate = Predicates.Field<AUDIT_LOG>(exp => exp.QUEUE_ID, Operator.Eq, queueId);
            return await Repository.DeleteAsync<AUDIT_LOG>(predicate, transaction) > 0 ? true : false;
        }

        public async Task<string> Add(AUDIT_LOG log,IDbTransaction transaction)
        {
            return await Repository.InsertAsync<AUDIT_LOG>(log,transaction);
        }

        public async Task<AUDIT_LOG> GetAsync(string queueId, string currentNodeId)
        {
            var predicateQueue = Predicates.Field<AUDIT_LOG>(exp => exp.QUEUE_ID, Operator.Eq, queueId);
            var predicateCurrentNode = Predicates.Field<AUDIT_LOG>(exp => exp.CURRENT_NODE_ID, Operator.Eq, currentNodeId);
            var predicateGroup = Predicates.Group(GroupOperator.And, predicateQueue, predicateCurrentNode);
            return await Repository.GetFirstAsync<AUDIT_LOG>(predicateGroup);
        }

        public async Task<IEnumerable<AUDIT_LOG>> GetGroupAsync(string queueId)
        {
            var predicateQueue = Predicates.Field<AUDIT_LOG>(exp => exp.QUEUE_ID, Operator.Eq, queueId);
            var predicateSort = Predicates.Sort<AUDIT_LOG>(exp => exp.OPERATION_TIME);
            return await Repository.GetListAsync<AUDIT_LOG>(predicateQueue, new[] { predicateSort });
        }
    }
}
