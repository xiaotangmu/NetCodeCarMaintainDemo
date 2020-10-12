using Entity.Workflow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Workflow
{
    interface IWorkflowOperation
    {
        /// <summary>
        /// 流程下一节点（入栈）
        /// </summary>
        Task<bool> Push();

        /// <summary>
        /// 退回上一节点（出栈）
        /// </summary>
        Task<bool> Pop();

        /// <summary>
        /// 当前节点（栈顶）
        /// </summary>
        Task<WORK_FLOW_NODES> GetTop();
    }
}
