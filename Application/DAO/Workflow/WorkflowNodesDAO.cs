using DAO;
using Entity.Workflow;
using ORM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interface.Workflow
{
    public class WorkflowNodesDAO : BaseDAO, IWorkflowNodesDAO
    {
        public WorkflowNodesDAO() : base() { }

        public WorkflowNodesDAO(IDataRepository repository) : base(repository) { }

        public async Task<IEnumerable<WORK_FLOW_NODES>> GetAsync(string workflowCode)
        {
            string sql = string.Format("SELECT * FROM work_flow_nodes WHERE flow_id IN (SELECT id FROM work_flow WHERE flow_code='{0}') ORDER BY node_index", workflowCode);
            return await Repository.GetGroupAsync<WORK_FLOW_NODES>(sql);
        }

        public async Task<WORK_FLOW_NODES> GetByIdAsync(string id)
        {
            return await Repository.GetByIdAsync<WORK_FLOW_NODES>(id);
        }
    }
}
