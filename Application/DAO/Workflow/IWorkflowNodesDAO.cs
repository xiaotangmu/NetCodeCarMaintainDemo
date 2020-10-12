using Entity.Workflow;
using Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Workflow
{
    public interface IWorkflowNodesDAO : IBaseRepository
    {
        Task<IEnumerable<WORK_FLOW_NODES>> GetAsync(string workflowCode);

        Task<WORK_FLOW_NODES> GetByIdAsync(string id);
    }
}
