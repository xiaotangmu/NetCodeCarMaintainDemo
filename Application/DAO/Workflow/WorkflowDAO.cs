using DAO;
using DapperExtensions;
using Entity.Workflow;
using ORM;
using System.Threading.Tasks;

namespace Interface.Workflow
{
    public class WorkflowDAO : BaseDAO, IWorkflowDAO
    {
        public WorkflowDAO() : base() { }

        public WorkflowDAO(IDataRepository repository) : base(repository) { }

        public async Task<WORK_FLOW> GetAsync(string code)
        {
            var predicate = Predicates.Field<WORK_FLOW>(exp => exp.FLOW_CODE, Operator.Eq, code);
            return await Repository.GetFirstAsync<WORK_FLOW>(predicate);
        }

        public async Task<bool> CanAuditWorkflowNode(string account, string nodeId)
        {
            string sql = @"SELECT COUNT(*) FROM t_system_userrole WHERE account='{0}' AND role_code IN (
														SELECT role_code FROM work_flow_nodes WHERE id='{1}')";

            return await Repository.CountAsync(string.Format(sql, account, nodeId)) > 0 ? true : false;
        }
    }
}
