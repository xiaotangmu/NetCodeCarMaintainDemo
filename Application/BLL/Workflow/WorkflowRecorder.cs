using Interface.Workflow;
using DataModel.System;
using DataModel.Workflow;
using Entity.Workflow;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Workflow
{
    public class WorkflowRecorder:BaseBLL
    {
        private IAuditLogDAO _auditLogDAO;
        private IAuditQueueDAO _auditQueueDAO;

        public WorkflowRecorder(IAuditLogDAO auditLogDAO = null, IAuditQueueDAO auditQueueDAO = null)
        {
            _auditQueueDAO = InitDAO<AuditQueueDAO>(auditQueueDAO) as IAuditQueueDAO;
            _auditLogDAO = InitDAO<AuditLogDAO>(auditLogDAO) as IAuditLogDAO;
        }

        public async Task<bool> Record(AuditModel auditModel, CurrentUserInfo userInfo, IDbTransaction transaction)
        {
            AUDIT_QUEUE queue = await _auditQueueDAO.GetAsync(auditModel.OrderNumber, auditModel.Type);
            if (queue == null)
            {
                return false;
            }
            AUDIT_LOG log = new AUDIT_LOG();
            log.QUEUE_ID = queue.ID;
            log.CURRENT_NODE_ID = queue.CURRENT_NODE_ID;
            log.FRONT_NODE_ID = queue.FRONT_NODE_ID;
            if (auditModel.AuditInfo != null)
            {
                log.NODE_RESULT = (auditModel.AuditInfo.IsPass) ? ((int)AuditStatus.PASS).ToString() : ((int)AuditStatus.REFUSE).ToString();
                log.OPERATION_REMARK = auditModel.AuditInfo.AuditRemark;
            }
            //log.CURRENT_NODE_STATUS = ((int)auditModel.CurrentStatus).ToString();
            log.OPERATION_USER = userInfo.Name;
            log.OPERATION_TIME = DateTime.Now;
            log.CREATE_TIME = DateTime.Now;
            string id = await _auditLogDAO.Add(log, transaction);
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            return true;
        }
    }
}
