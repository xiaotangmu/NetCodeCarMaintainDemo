using System.Data;
using System.Threading.Tasks;
using DAO;
using DapperExtensions;
using DataModel.System;
using DataModel.Workflow;
using Entity.Workflow;
using ORM;

namespace Interface.Workflow
{
    public class AuditQueueDAO : BaseDAO, IAuditQueueDAO
    {
        public AuditQueueDAO() : base() { }

        public AuditQueueDAO(IDataRepository repository) : base(repository) { }

        public async Task<string> Add(AUDIT_QUEUE queue,IDbTransaction transaction)
        {
            return await Repository.InsertAsync(queue, transaction);
        }

        public async Task<AUDIT_QUEUE> GetAsync(string orderNumber, WorkflowType type)
        {
            var predicateOrder = Predicates.Field<AUDIT_QUEUE>(exp => exp.ORDER_NUMBER, Operator.Eq, orderNumber);
            var predicateType = Predicates.Field<AUDIT_QUEUE>(exp => exp.ORDER_TYPE, Operator.Eq, ((int)type).ToString());
            var predicateGroup = Predicates.Group(GroupOperator.And, predicateOrder, predicateType);
            return await Repository.GetFirstAsync<AUDIT_QUEUE>(predicateGroup);
        }

        public async Task<bool> UpdateAsync(UpdateModel info, IDbTransaction transaction = null)
        {
            return await Repository.UpdateAsync<AUDIT_QUEUE>(info.SetCollection, info.WhereCollection, transaction);
        }

        public async Task<bool> DeleteAsync(string id, IDbTransaction transaction)
        {
            return await Repository.DeleteAsync<AUDIT_QUEUE>(id, transaction) > 0 ? true : false;
        }
    }
}
