using BLL.System;
using Interface.System;
using Interface.Workflow;
using DataModel.System;
using DataModel.Workflow;
using Entity.Workflow;
using Localization;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Workflow
{
    public class AuditQueue : BaseBLL
    {
        private IAuditQueueDAO _auditQueueDAO;
        private IAuditLogDAO _auditLogDAO;
        private IWorkflowDAO _workflowDAO;
        private IWorkflowNodesDAO _workflowNodesDAO;
        private IRoleDAO _roleDAO;

        public AuditQueue(IAuditQueueDAO auditQueueDAO = null,
                                        IAuditLogDAO auditLogDAO = null,
                                        IWorkflowDAO workflowDAO = null,
                                        IWorkflowNodesDAO workflowNodesDAO = null,
                                        IRoleDAO roleDAO = null)
        {
            _auditQueueDAO = InitDAO<AuditQueueDAO>(auditQueueDAO) as IAuditQueueDAO;
            _auditLogDAO = InitDAO<AuditLogDAO>(auditLogDAO) as IAuditLogDAO;
            _workflowDAO = InitDAO<WorkflowDAO>(workflowDAO) as IWorkflowDAO;
            _workflowNodesDAO = InitDAO<WorkflowNodesDAO>(workflowNodesDAO) as IWorkflowNodesDAO;
            _roleDAO = InitDAO<RoleDAO>(roleDAO) as IRoleDAO;
        }

        private void InitDAO(IAuditQueueDAO auditQueueDAO, IAuditLogDAO auditLogDAO,
                                            IWorkflowDAO workflowDAO, IWorkflowNodesDAO workflowNodesDAO, IRoleDAO roleDAO)
        {
            InitAuditQueueDAO(auditQueueDAO);
            InitAuditLogDAO(auditLogDAO);
            InitWorkflowDAO(workflowDAO);
            InitWorkflowNodesDAO(workflowNodesDAO);
            InitRoleDAO(roleDAO);
        }

        private void InitWorkflowNodesDAO(IWorkflowNodesDAO workflowNodesDAO)
        {
            if (workflowNodesDAO == null)
            {
                workflowNodesDAO = new WorkflowNodesDAO(_auditQueueDAO?.Repository);
            }
            _workflowNodesDAO = workflowNodesDAO;
        }

        private void InitRoleDAO(IRoleDAO roleDAO)
        {
            if (roleDAO == null)
            {
                roleDAO = new RoleDAO(_auditQueueDAO.Repository);
            }
            _roleDAO = roleDAO;
        }

        private void InitAuditQueueDAO(IAuditQueueDAO auditQueueDAO)
        {
            if (auditQueueDAO == null)
            {
                auditQueueDAO = new AuditQueueDAO();
            }
            _auditQueueDAO = auditQueueDAO;
        }

        private void InitAuditLogDAO(IAuditLogDAO auditLogDAO)
        {
            if (auditLogDAO == null)
            {
                auditLogDAO = new AuditLogDAO(_auditQueueDAO?.Repository);
            }
            _auditLogDAO = auditLogDAO;
        }

        private void InitWorkflowDAO(IWorkflowDAO workflowDAO)
        {
            if (workflowDAO == null)
            {
                workflowDAO = new WorkflowDAO(_auditQueueDAO?.Repository);
            }
            _workflowDAO = workflowDAO;
        }

        public async Task<AUDIT_QUEUE> Create(string orderId, WorkflowType type, CurrentUserInfo userInfo, IDbTransaction transaction)
        {
            WorkflowModel workflow = await new WorkflowManagement(_workflowDAO, _workflowNodesDAO, _roleDAO).GetWorkflow(type);
            return await CreateAuditQueue(orderId, workflow, userInfo, transaction);
        }

        public async Task<bool> UpdateStatus(AuditModel auditModel, AuditStatus auditStatus, CurrentUserInfo userInfo, IDbTransaction transaction = null)
        {
            UpdateModel statusUpdate = new UpdateModel();
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_CHECK_STATUS, ((int)auditStatus).ToString());
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_UPDATE_TIME, DateTime.Now);
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_MODIFY_USER, userInfo.Name);
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_APPLY_USER, userInfo.Name);
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_APPLY_TIME, DateTime.Now);

            statusUpdate.WhereCollection.Add(AUDIT_QUEUE.FIELD_ORDER_NUMBER, auditModel.OrderNumber);
            statusUpdate.WhereCollection.Add(AUDIT_QUEUE.FIELD_ORDER_TYPE, ((int)auditModel.Type).ToString());
            return await _auditQueueDAO.UpdateAsync(statusUpdate, transaction);
        }

        public async Task<bool> UpdateQueueToNextNode(AuditModel model, AUDIT_QUEUE queue, CurrentUserInfo currentUser, IDbTransaction transaction)
        {
            UpdateModel statusUpdate = new UpdateModel();
            //下一节点即更新后的当前节点
            WorkflowNodeModel nextNode = await new WorkflowManagement(_workflowDAO, _workflowNodesDAO, _roleDAO).GetNextNode(queue.CURRENT_NODE_ID, model.Type);
            if (nextNode != null)
            {
                statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_CHECK_STATUS, ((int)AuditStatus.WAITTING).ToString());
                statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_CURRENT_NODE_ID, nextNode.NodeId);
            }
            else
            {
                statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_CHECK_STATUS, ((int)AuditStatus.END).ToString());
                statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_CURRENT_NODE_ID, null);
            }
            //当前节点为更新后的上一节点
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_FRONT_NODE_ID, queue.CURRENT_NODE_ID);
            if (model.AuditInfo != null)
            {
                statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_LAST_NODE_RESULT, model.AuditInfo.IsPass ? ((int)AuditStatus.PASS).ToString() : ((int)AuditStatus.REFUSE).ToString());
                statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_LAST_OPERATE_REMARK, model.AuditInfo.AuditRemark);
            }
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_LAST_OPERATE_ID, currentUser.Name);
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_LAST_OPERATE_TIME, DateTime.Now);
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_APPLY_TIME, DateTime.Now);
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_APPLY_USER, currentUser.Name);
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_UPDATE_TIME, DateTime.Now);
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_MODIFY_USER, currentUser.Name);

            statusUpdate.WhereCollection.Add(AUDIT_QUEUE.FIELD_ORDER_NUMBER, model.OrderNumber);
            statusUpdate.WhereCollection.Add(AUDIT_QUEUE.FIELD_ORDER_TYPE, ((int)model.Type).ToString());
            return await _auditQueueDAO.UpdateAsync(statusUpdate, transaction);
        }

        public async Task<bool> ReturnToFrontNode(AuditModel model, AUDIT_QUEUE queue, CurrentUserInfo currentUser, IDbTransaction transaction = null)
        {
            UpdateModel statusUpdate = new UpdateModel();
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_CHECK_STATUS, ((int)AuditStatus.WAITTING).ToString());
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_CURRENT_NODE_ID, queue.FRONT_NODE_ID);
            //获取当前节点的上一节点
            AUDIT_LOG log = await _auditLogDAO.GetAsync(queue?.ID, queue?.FRONT_NODE_ID);
            if (log != null)
            {
                statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_FRONT_NODE_ID, log.FRONT_NODE_ID);
            }
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_LAST_NODE_RESULT, ((int)AuditStatus.REFUSE).ToString());
            if (model.AuditInfo != null)
            {
                statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_LAST_OPERATE_REMARK, model.AuditInfo.AuditRemark);
            }
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_LAST_OPERATE_ID, currentUser.Name);
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_LAST_OPERATE_TIME, DateTime.Now);
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_UPDATE_TIME, DateTime.Now);
            statusUpdate.SetCollection.Add(AUDIT_QUEUE.FIELD_MODIFY_USER, currentUser.Name);

            statusUpdate.WhereCollection.Add(AUDIT_QUEUE.FIELD_ORDER_NUMBER, model.OrderNumber);
            statusUpdate.WhereCollection.Add(AUDIT_QUEUE.FIELD_ORDER_TYPE, ((int)model.Type).ToString());
            return await _auditQueueDAO.UpdateAsync(statusUpdate, transaction);
        }

        public async Task<bool> DestroyQueue(AUDIT_QUEUE queue)
        {
            return await _auditQueueDAO.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                return await DestroyQueueTransaction(queue, transaction);
            });
        }

        private async Task<bool> DestroyQueueTransaction(AUDIT_QUEUE queue, IDbTransaction transaction)
        {
            //销毁记录
            bool isSuccessful = await _auditLogDAO.DeleteAsync(queue.ID, transaction);
            //销毁队列
            if (isSuccessful)
            {
                isSuccessful = await _auditQueueDAO.DeleteAsync(queue.ID, transaction);
            }
            return isSuccessful;
        }

        private async Task<AUDIT_QUEUE> CreateAuditQueue(string orderNumber, WorkflowModel workflow, CurrentUserInfo userInfo, IDbTransaction transaction)
        {
            AUDIT_QUEUE queue = new AUDIT_QUEUE();
            queue.CHECK_STATUS = ((int)AuditStatus.WAITTING).ToString();
            //当前节点
            WorkflowNodeModel currentNode = workflow.NodeGroup?.FirstOrDefault();
            if (currentNode != null)
            {
                queue.CURRENT_NODE_ID = currentNode.NodeId;
            }
            queue.ORDER_NUMBER = orderNumber;
            queue.ORDER_TYPE = ((int)workflow.Type).ToString();
            queue.APPLY_TIME = DateTime.Now;
            queue.APPLY_USER = userInfo.Name;
            string id = await _auditQueueDAO.Add(queue, transaction);
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            return queue;
        }

        /// <summary>
        /// 撤回，第一节点时当前节点不变，只改变状态为“未提交审核”；
        /// 非第一节点时，当前节点退回上一节点，状态为“待审核”
        /// </summary>
        public async Task<bool> Recall(AuditModel model, AUDIT_QUEUE queue, CurrentUserInfo userInfo, IDbTransaction transaction)
        {
            if (string.IsNullOrEmpty(queue.FRONT_NODE_ID) || queue.FRONT_NODE_ID.Equals(queue.CURRENT_NODE_ID))
            {
                return await UpdateStatus(model, AuditStatus.NOT_COMMIT, userInfo, transaction);
            }
            else
            {
                return await ReturnToFrontNode(model, queue, userInfo, transaction);
            }
        }
    }
}
