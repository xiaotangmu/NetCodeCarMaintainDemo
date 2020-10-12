using DataModel.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Workflow
{
    public class WorkflowModel
    {
        public string FlowId { get; set; }

        public string WorkflowCode { get; set; }

        public string WorkflowName { get; set; }

        public WorkflowType Type { get; set; }

        public List<WorkflowNodeModel> NodeGroup { get; set; } = new List<WorkflowNodeModel>();
    }

    public class WorkflowNodeModel
    {
        public string NodeId { get; set; }

        public string NodeCode { get; set; }

        public string NodeName { get; set; }

        public int Index { get; set; }

        public RoleModel Role { get; set; }
    }
}
