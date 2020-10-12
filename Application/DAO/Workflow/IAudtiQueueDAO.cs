using DataModel.System;
using DataModel.Workflow;
using Entity.Workflow;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Workflow
{
    public interface IAuditQueueDAO : IBaseRepository
    {
        Task<string> Add(AUDIT_QUEUE queue,IDbTransaction transaction);

        Task<AUDIT_QUEUE> GetAsync(string orderNumber, WorkflowType type);

        Task<bool> UpdateAsync(UpdateModel updateModel, IDbTransaction transaction = null);

        Task<bool> DeleteAsync(string id, IDbTransaction transaction = null);
    }
}
