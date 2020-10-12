
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Workflow
{
    public class QueueKeyModel
    {
        /// <summary>
        /// 业务ID
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// 流程类型
        /// </summary>
        public WorkflowType Type { get; set; }

        /// <summary>
        /// 当前业务状态
        /// </summary>
        //public MaintenanceStatus CurrentStatus { get; set; }
    }

    public class AuditModel : QueueKeyModel
    {
        public AuditBaseInfo AuditInfo { get; set; }
    }


    public class AuditBaseInfo
    {
        public bool IsPass { get; set; }

        public string AuditRemark { get; set; }
    }
}
