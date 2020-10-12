using Entity.Workflow;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Workflow
{
    public interface IAuditLogDAO : IBaseRepository
    {
        Task<bool> DeleteAsync(string queueId, IDbTransaction transaction);

        Task<string> Add(AUDIT_LOG log, IDbTransaction transaction);

        Task<AUDIT_LOG> GetAsync(string queueId, string currentNodeId);

        Task<IEnumerable<AUDIT_LOG>> GetGroupAsync(string queueId);
    }
}
