using BLL.System;
using Interface.System;
using Interface.Workflow;
using DataModel.System;
using DataModel.Workflow;
using Entity.Workflow;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Workflow
{
    public class WorkflowManagement:BaseBLL
    {
        //固定的工作流流程编码
        private readonly string maintenace_code = "maintenance";
        private readonly string material_return_code = "material_return";
        private readonly string material_recipient_code = "material_recipient";

        private IWorkflowDAO _workflowDAO;
        private IWorkflowNodesDAO _workflowNodesDAO;
        private IRoleDAO _roleDAO;

        public WorkflowManagement(IWorkflowDAO workflowDAO = null,
                                                            IWorkflowNodesDAO workflowNodesDAO = null,
                                                                IRoleDAO roleDAO = null)
        {
            _workflowDAO = InitDAO<WorkflowDAO>(workflowDAO) as IWorkflowDAO;
            _workflowNodesDAO = InitDAO<WorkflowNodesDAO>(workflowNodesDAO) as IWorkflowNodesDAO;
            _roleDAO = InitDAO<RoleDAO>(roleDAO) as IRoleDAO;
        }

        public async Task<WorkflowModel> GetWorkflow(WorkflowType type)
        {
            WorkflowModel model = new WorkflowModel();
            switch (type)
            {
                case WorkflowType.MAINTENANCE:
                    model = await BuildWorkflowModel(maintenace_code);
                    break;
                case WorkflowType.MATERIAL_RECIPIENT:
                    model = await BuildWorkflowModel(material_recipient_code);
                    break;
                case WorkflowType.MATERIAL_RETURN:
                    model = await BuildWorkflowModel(material_return_code);
                    break;
            }
            model.Type = type;
            return model;
        }

        public async Task<WorkflowNodeModel> GetNextNode(string currentNodeId, WorkflowType type)
        {
            WorkflowModel workflow = await GetWorkflow(type);
            int currentIndex = workflow.NodeGroup.FindIndex(exp => exp.NodeId == currentNodeId);
            if (currentIndex < 0 || workflow.NodeGroup.Count <= currentIndex + 1)
            {
                return null;
            }
            return workflow.NodeGroup[currentIndex + 1];
        }

        public async Task<bool> IsCanAudit(string nodeId, CurrentUserInfo userInfo)
        {
            return await _workflowDAO.CanAuditWorkflowNode(userInfo.Name, nodeId);
        }

        public async Task<WorkflowNodeModel> GetCurrentAuditNode(string currentNodeId)
        {
            WORK_FLOW_NODES entity = await _workflowNodesDAO.GetByIdAsync(currentNodeId);
            if (entity == null)
            {
                throw new Exception(await Localization.Localizer.GetValueAsync("當前節點不存在"));
            }
            return new WorkflowNodeModel
            {
                NodeId = entity.ID,
                NodeCode = entity.NODE_CODE,
                NodeName = entity.NODE_NAME,
                Index = entity.NODE_INDEX,
                Role = await new RoleManagement(_roleDAO).Get(entity.ROLE_ID)
            };
        }

        private async Task<WorkflowModel> BuildWorkflowModel(string code)
        {
            WORK_FLOW flow = await _workflowDAO.GetAsync(code);
            if (flow == null)
            {
                return null;
            }
            WorkflowModel model = new WorkflowModel();
            model.FlowId = flow.ID;
            model.WorkflowCode = flow.FLOW_CODE;
            model.WorkflowName = flow.FLOW_NAME;
            model.NodeGroup = await GetWorkflowNodeGroup(model.WorkflowCode);
            return model;
        }

        private async Task<List<WorkflowNodeModel>> GetWorkflowNodeGroup(string workflowCode)
        {
            List<WORK_FLOW_NODES> nodeGroup = (await _workflowNodesDAO.GetAsync(workflowCode))?.ToList();
            if (nodeGroup == null)
            {
                return null;
            }
            List<WorkflowNodeModel> models = new List<WorkflowNodeModel>();
            foreach (WORK_FLOW_NODES node in nodeGroup)
            {
                models.Add(new WorkflowNodeModel
                {
                    NodeId = node.ID,
                    NodeCode = node.NODE_CODE,
                    NodeName = node.NODE_NAME,
                    Index = node.NODE_INDEX,
                    Role = await new RoleManagement(_roleDAO).Get(node.ROLE_ID)
                });
            }
            return models;
        }
    }
}
