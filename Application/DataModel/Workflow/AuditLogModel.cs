using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Workflow
{
    public class AuditLogModel
    {
        /// <summary>
        /// 审核队列ID
        /// </summary>
        public string QueueId { get; set; }

        /// <summary>
        /// 当前审核状态
        /// </summary>
        public AuditStatus Status { get; set; }

        /// <summary>
        /// 审核意见
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 当前节点ID
        /// </summary>
        public string CurrentNodeId { get; set; }

        /// <summary>
        /// 下一节点ID
        /// </summary>
        public string NextNodeId { get; set; }
    }
}
