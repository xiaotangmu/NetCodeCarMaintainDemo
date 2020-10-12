using Entity.Workflow;
using Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Workflow
{
    public interface IWorkflowDAO : IBaseRepository
    {
        Task<WORK_FLOW> GetAsync(string code);

        Task<bool> CanAuditWorkflowNode(string account, string nodeId);
    }
}
