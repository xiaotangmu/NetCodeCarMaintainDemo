using Interface.System;
using Interface.Workflow;
using DataModel.System;
using DataModel.Workflow;
using Entity.Workflow;
using Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Workflow
{
    public class WorkflowCore : BaseBLL
    {
        private IAuditQueueDAO _auditQueueDAO;
        private IAuditLogDAO _auditLogDAO;
        private IWorkflowDAO _workflowDAO;
        private IWorkflowNodesDAO _workflowNodesDAO;
        private IRoleDAO _roleDAO;

        public WorkflowCore(IAuditQueueDAO auditQueueDAO = null,
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

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Commit(QueueKeyModel keyModel, CurrentUserInfo userInfo, IDbTransaction transaction)
        {
            bool isSuccessful = false;
            AUDIT_QUEUE queue = await _auditQueueDAO.GetAsync(keyModel.OrderNumber, keyModel.Type);
            if (queue == null)
            {
                isSuccessful = await CreateQueue(keyModel, userInfo, transaction);
            }
            else
            {
                isSuccessful = await UpdateQuqueStatus(keyModel, userInfo, transaction);
            }
            return isSuccessful;
        }

        private async Task<bool> UpdateQuqueStatus(QueueKeyModel keyModel, CurrentUserInfo userInfo, IDbTransaction transaction)
        {
            UpdateModel update = new UpdateModel();
            update.SetCollection.Add(AUDIT_QUEUE.FIELD_CHECK_STATUS, ((int)AuditStatus.WAITTING).ToString());
            update.SetCollection.Add(AUDIT_QUEUE.FIELD_LUD, DateTime.Now);
            update.SetCollection.Add(AUDIT_QUEUE.FIELD_MODIFY_USER, userInfo.Name);
            update.WhereCollection.Add(AUDIT_QUEUE.FIELD_ORDER_NUMBER, keyModel.OrderNumber);
            update.WhereCollection.Add(AUDIT_QUEUE.FIELD_ORDER_TYPE, ((int)keyModel.Type).ToString());
            return await _auditQueueDAO.UpdateAsync(update, transaction);
        }

        private async Task<bool> CreateQueue(QueueKeyModel keyModel, CurrentUserInfo userInfo, IDbTransaction transaction)
        {
            AUDIT_QUEUE queue = await new AuditQueue(_auditQueueDAO, _auditLogDAO, _workflowDAO,
                _workflowNodesDAO, _roleDAO).Create(keyModel.OrderNumber, keyModel.Type, userInfo, transaction);
            if (queue != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Audit(AuditModel auditModel, CurrentUserInfo currentUser, IDbTransaction transaction = null)
        {
            AUDIT_QUEUE queue = await _auditQueueDAO.GetAsync(auditModel.OrderNumber, auditModel.Type);
            if (queue == null)
            {
                throw new Exception(await Localizer.GetValueAsync("未提交"));
            }
            //不通过审核
            if (!auditModel.AuditInfo.IsPass)
            {
                return await NotPassAudit(auditModel, queue, currentUser, transaction);
            }
            return await IsPassAudit(auditModel, queue, currentUser, transaction);
        }

        private async Task<bool> IsPassAudit(AuditModel auditModel, AUDIT_QUEUE queue, CurrentUserInfo currentUser, IDbTransaction transaction = null)
        {
            if (await IsLastNode(queue.CURRENT_NODE_ID, auditModel.Type))
            {
                return await FlowEnd(auditModel, currentUser, transaction);
            }
            //审核通过并有下一节点流程，则进行流转
            return await FlowToNext(auditModel, queue, currentUser, transaction);
        }

        private async Task<bool> NotPassAudit(AuditModel auditModel, AUDIT_QUEUE queue, CurrentUserInfo currentUser, IDbTransaction transaction = null)
        {
            //上一节点为空，即只将状态变成“未提交审核”，节点不退回
            if (string.IsNullOrEmpty(queue.FRONT_NODE_ID))
            {
                return await UpdateQueueStatusAndRecord(auditModel, AuditStatus.REFUSE, currentUser, transaction);
            }
            else
            {
                return await FlowReturn(auditModel, queue, currentUser, transaction);
            }
        }

        /// <summary>
        /// 能否有权限审核
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsCanAudit(QueueKeyModel key, CurrentUserInfo userInfo)
        {
            AUDIT_QUEUE queue = await _auditQueueDAO.GetAsync(key.OrderNumber, key.Type);
            //未提交时，状态为空
            if (queue == null)
            {
                return false;
            }
            //审核队列的审核状态非待审核时，不需审核
            AuditStatus currentNodeStatus = (AuditStatus)int.Parse(queue.CHECK_STATUS);
            if (currentNodeStatus == AuditStatus.PASS || currentNodeStatus == AuditStatus.NOT_COMMIT
                || currentNodeStatus == AuditStatus.REFUSE || currentNodeStatus == AuditStatus.END)
            {
                return false;
            }
            if (userInfo.UserType == UserType.VISITOR)
            {
                return false;
            }
            return await new WorkflowManagement(_workflowDAO, _workflowNodesDAO, _roleDAO).IsCanAudit(queue.CURRENT_NODE_ID, userInfo);
        }

        /// <summary>
        /// 锁定审核队列
        /// </summary>
        /// <param name="model">业务单号，资产登记则为资产编号</param>
        /// <param name="currentUser">当前用户信息</param>
        /// <returns></returns>
        public async Task<bool> Lock(QueueKeyModel model, CurrentUserInfo currentUser)
        {
            return true;
            //AUDIT_QUEUE queue = await _auditQueueDAO.GetAsync(model.OrderNumber, model.Type);
            //if (queue == null)
            //{
            //    return false;
            //}
            //if (!string.IsNullOrEmpty(queue.LOCK_USER))
            //{
            //    return true;
            //}
            //UpdateModel update = new UpdateModel();
            //update.SetCollection.Add(AUDIT_QUEUE.FIELD_LOCK_USER, currentUser.Account);
            //update.SetCollection.Add(AUDIT_QUEUE.FIELD_LOCK_TIME, DateTime.Now);
            //update.WhereCollection.Add(AUDIT_QUEUE.FIELD_ORDER_NUMBER, queue.ORDER_NUMBER);
            //update.WhereCollection.Add(AUDIT_QUEUE.FIELD_ORDER_TYPE, queue.ORDER_TYPE);
            //return await _auditQueueDAO.UpdateAsync(update);
        }

        /// <summary>
        /// 解锁审核队列
        /// </summary>
        /// <returns></returns>
        public async Task<bool> UnLock(QueueKeyModel model, CurrentUserInfo currentUser)
        {
            return true;
            //AUDIT_QUEUE queue = await _auditQueueDAO.GetAsync(model.OrderNumber, model.Type);
            //if (queue == null)
            //{
            //    return false;
            //}
            //UpdateModel update = new UpdateModel();
            //update.SetCollection.Add(AUDIT_QUEUE.FIELD_LOCK_USER, "");
            //update.WhereCollection.Add(AUDIT_QUEUE.FIELD_ORDER_NUMBER, queue.ORDER_NUMBER);
            //update.WhereCollection.Add(AUDIT_QUEUE.FIELD_ORDER_TYPE, queue.ORDER_TYPE);
            //return await _auditQueueDAO.UpdateAsync(update);
        }

        /// <summary>
        /// 判断单据是否锁定，且判断是否当前登录用户进行的锁定
        /// 用于业务控制
        /// </summary>
        /// <param name="orderNum"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public async Task<bool> IsUserLock(AuditModel model, CurrentUserInfo currentUser)
        {
            AUDIT_QUEUE queue = await _auditQueueDAO.GetAsync(model.OrderNumber, model.Type);
            if (queue == null || string.IsNullOrEmpty(queue.LOCK_USER))
            {
                return false;
            }
            return queue.LOCK_USER.Equals(currentUser.Name);
        }

        /// <summary>
        /// 撤回
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Recall(AuditModel model, CurrentUserInfo userInfo, IDbTransaction transaction)
        {
            AUDIT_QUEUE queue = await _auditQueueDAO.GetAsync(model.OrderNumber, model.Type);
            if (queue == null)
            {
                return false;
            }
            //约束判断，并会抛出异常
            await ConstraintException(queue, userInfo);

            return await new AuditQueue(_auditQueueDAO, _auditLogDAO, _workflowDAO,
                   _workflowNodesDAO, _roleDAO).Recall(model, queue, userInfo, transaction);
        }

        /// <summary>
        /// 删除审核队列（当业务被删除时，应清除对应的工作流）
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteWorkflow(QueueKeyModel model)
        {
            AUDIT_QUEUE queue = await _auditQueueDAO.GetAsync(model.OrderNumber, model.Type);
            if (queue == null)
            {
                return false;
            }
            return await new AuditQueue(_auditQueueDAO, _auditLogDAO, _workflowDAO, _workflowNodesDAO, _roleDAO).DestroyQueue(queue);
        }

        public async Task<List<AuditRecord>> GetAuditTrace(string orderNumber, WorkflowType workflowType)
        {
            AUDIT_QUEUE queue = await _auditQueueDAO.GetAsync(orderNumber, workflowType);
            IEnumerable<AUDIT_LOG> logGroup = await _auditLogDAO.GetGroupAsync(queue?.ID);
            if (logGroup == null)
            {
                return null;
            }
            return await BuildAuditRecordGroup(queue, logGroup);
        }

        private async Task<List<AuditRecord>> BuildAuditRecordGroup(AUDIT_QUEUE queue, IEnumerable<AUDIT_LOG> logGroup)
        {
            List<AuditRecord> historyRecord = new List<AuditRecord>();
            foreach (AUDIT_LOG log in logGroup)
            {
                AuditRecord record = await BuildAuditRecord(log);
                if (record == null)
                {
                    continue;
                }
                historyRecord.Add(record);
            }
            //historyRecord.Add(await BuildCurrentNode(queue));
            return historyRecord;
        }

        private async Task<AuditRecord> BuildCurrentNode(AUDIT_QUEUE queue)
        {
            AuditRecord record = new AuditRecord();
            record.FlowNodeName = (await _workflowNodesDAO.GetByIdAsync(queue.CURRENT_NODE_ID))?.NODE_NAME;
            record.IsCurrent = true;
            return record;
        }

        private async Task<AuditRecord> BuildAuditRecord(AUDIT_LOG log)
        {
            AuditRecord record = new AuditRecord();
            record.FlowNodeName = (await _workflowNodesDAO.GetByIdAsync(log.CURRENT_NODE_ID))?.NODE_NAME;
            record.Auditor = log.OPERATION_USER;
            record.AuditRemark = log.OPERATION_REMARK;
            record.AuditTime = DateTimeConverter.ConvertToString(log.OPERATION_TIME);
            record.AuditStatus = AuditStatusConverter.ConvertStringToDisplay(log.NODE_RESULT);
            return record;
        }

        private async Task<bool> IsLastNode(string currentNodeId, WorkflowType type)
        {
            WorkflowNodeModel nextNode = await new WorkflowManagement(
                _workflowDAO,
                _workflowNodesDAO,
                _roleDAO).GetNextNode(currentNodeId, type);
            if (nextNode == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 约束条件，并抛出异常
        /// </summary>
        /// <param name="queue">审核队列</param>
        /// <param name="currentUser">当前用户</param>
        private async Task ConstraintException(AUDIT_QUEUE queue, CurrentUserInfo currentUser)
        {
            ////非申请本人不可以撤回
            //if (!Equals(currentUser.Account, queue.APPLY_USER))
            //{
            //    throw new Exception(await Localizer.GetValueAsync("WorkflowCoreBLL_Exception_Applicant"));
            //}
            //处于待审时，才可以撤回
            if (Equals(queue.CHECK_STATUS, ((int)AuditStatus.WAITTING)))
            {
                throw new Exception(await Localizer.GetValueAsync("WorkflowCoreBLL_Exception_NoSumit"));
            }
            if (Equals(queue.CHECK_STATUS, ((int)AuditStatus.PASS)))
            {
                throw new Exception(await Localizer.GetValueAsync("WorkflowCoreBLL_Exception_HaveAudited"));
            }
            if (Equals(queue.CHECK_STATUS, ((int)AuditStatus.REFUSE)))
            {
                throw new Exception(await Localizer.GetValueAsync("WorkflowCoreBLL_Exception_HaveRefused"));
            }
            //审核锁定时，不可撤回
            if (!string.IsNullOrEmpty(queue.LOCK_USER) && !queue.LOCK_USER.Equals(currentUser.Name))
            {
                throw new Exception(await Localizer.GetValueAsync("WorkflowCoreBLL_Exception_IsAuditing"));
            }
        }

        /// <summary>
        /// 退回，当上一节点为空时，队列节点信息不变，状态更新为“未提交审核”
        /// </summary>
        /// <returns></returns>
        private async Task<bool> FlowReturn(AuditModel model, AUDIT_QUEUE queue, CurrentUserInfo userInfo, IDbTransaction transaction = null)
        {
            if (transaction == null)
            {
                return await _workflowDAO.Repository.DbSession.TransactionHandle(async (tran) =>
                {
                    return await ReturnToFrontNode(model, queue, userInfo, tran);
                });
            }
            return await ReturnToFrontNode(model, queue, userInfo, transaction);
        }

        private async Task<bool> ReturnToFrontNode(AuditModel model, AUDIT_QUEUE queue, CurrentUserInfo userInfo, IDbTransaction transaction)
        {
            //记录审核结果
            bool isSuccessful = await new WorkflowRecorder(_auditLogDAO, _auditQueueDAO).Record(model, userInfo, transaction);
            if (isSuccessful)
            {
                //退回
                isSuccessful = await new AuditQueue(_auditQueueDAO, _auditLogDAO,
                    _workflowDAO, _workflowNodesDAO, _roleDAO).ReturnToFrontNode(model, queue, userInfo);
            }
            return isSuccessful;
        }

        private async Task<bool> FlowEnd(AuditModel model, CurrentUserInfo userInfo, IDbTransaction transaction = null)
        {
            return await UpdateQueueStatusAndRecord(model, AuditStatus.END, userInfo, transaction);
        }

        private async Task<bool> UpdateQueueStatusAndRecord(AuditModel model, AuditStatus status, CurrentUserInfo userInfo, IDbTransaction transaction = null)
        {
            if (transaction == null)
            {
                return await _workflowDAO.Repository.DbSession.TransactionHandle(async (tran) =>
               {
                   return await UpdateQueueStatusAndRecordWithTransaction(model, status, userInfo, transaction);
               });
            }
            return await UpdateQueueStatusAndRecordWithTransaction(model, status, userInfo, transaction);
        }

        private async Task<bool> UpdateQueueStatusAndRecordWithTransaction(AuditModel model, AuditStatus status, CurrentUserInfo userInfo, IDbTransaction transaction)
        {
            bool isSuccessful = await new WorkflowRecorder(_auditLogDAO, _auditQueueDAO).Record(model, userInfo, transaction);
            if (isSuccessful)
            {
                //更新审核队列状态
                isSuccessful = await new AuditQueue(_auditQueueDAO, _auditLogDAO,
                    _workflowDAO, _workflowNodesDAO, _roleDAO).UpdateStatus(model, status, userInfo, transaction);
            }
            return isSuccessful;
        }

        private async Task<bool> FlowToNext(AuditModel model, AUDIT_QUEUE queue, CurrentUserInfo currentUser, IDbTransaction transaction = null)
        {
            if (transaction == null)
            {
                return await _workflowDAO.Repository.DbSession.TransactionHandle(async (tran) =>
               {
                   return await FlowToNextNode(model, queue, currentUser, tran);
               });
            }
            return await FlowToNextNode(model, queue, currentUser, transaction);
        }

        private async Task<bool> FlowToNextNode(AuditModel model, AUDIT_QUEUE queue, CurrentUserInfo currentUser, IDbTransaction transaction)
        {
            //记录审核结果
            bool isSuccessful = await new WorkflowRecorder(_auditLogDAO, _auditQueueDAO).Record(model, currentUser, transaction);
            if (isSuccessful)
            {
                //审核队列信息更新为下一节点
                isSuccessful = await new AuditQueue(_auditQueueDAO, _auditLogDAO,
                    _workflowDAO, _workflowNodesDAO, _roleDAO).UpdateQueueToNextNode(model, queue, currentUser, transaction);
            }
            return isSuccessful;
        }
    }
}
