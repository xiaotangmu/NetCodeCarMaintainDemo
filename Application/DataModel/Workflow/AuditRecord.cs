using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Workflow
{
    public class AuditRecord
    {
        public string FlowNodeName { get; set; }

        public string AuditStatus { get; set; }

        public string Auditor { get; set; }

        public string AuditTime { get; set; }

        public string AuditRemark { get; set; }

        public bool IsCurrent { get; set; }
    }
}
