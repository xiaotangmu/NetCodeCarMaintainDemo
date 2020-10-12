using DataModel.System;
using DataModel.Workflow;
using Entity.Workflow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Workflow
{
    public interface IWorkflow
    {
        /// <summary>
        /// 獲取審核軌跡
        /// </summary>
        Task<List<AuditRecord>> GetAuditTrace(string orderNumber);

        /// <summary>
        /// 撤回，已提交下一流程但未審核時，可進行撤回
        /// </summary>
        Task<bool> Recall(string orderNumber, CurrentUserInfo userInfo);

        /// <summary>
        /// 提交到下一流程
        /// </summary>
        Task<bool> Commit(string orderNumber, CurrentUserInfo userInfo);

        /// <summary>
        /// 鎖定流程，只允許鎖定人進行操作，直至解鎖
        /// </summary>
        Task<bool> Lock(string orderNumber, CurrentUserInfo userInfo);

        /// <summary>
        /// 解鎖流程，只允許鎖定人進行解鎖操作
        /// </summary>
        Task<bool> UnLock(string orderNumber, CurrentUserInfo userInfo);
    }
}
