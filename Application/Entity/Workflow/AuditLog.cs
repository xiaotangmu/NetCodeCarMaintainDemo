using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/// <summary>
/// 作者：xavier
/// 日期：2019-04-26 09:42:19
/// 描述：
/// </summary>

namespace Entity.Workflow
{
    /// <summary>
    /// 审核结果记录
    /// </summary>
    [Serializable]
    public class AUDIT_LOG : BaseEntity
    {
        private string _queue_id;

        public static string FIELD_QUEUE_ID = "queue_id";
        /// <summary>
        /// 审核状态记录表ID
        /// </summary>
        public string QUEUE_ID
        {
            get { return _queue_id; }
            set { _queue_id = value; }
        }

        private string _current_node_id;

        public static string FIELD_CURRENT_NODE_ID = "current_node_id";
        /// <summary>
        /// 当前节点ID
        /// </summary>
        public string CURRENT_NODE_ID
        {
            get { return _current_node_id; }
            set { _current_node_id = value; }
        }

        private string _front_node_id;

        public static string FIELD_FRONT_NODE_ID = "front_node_id";
        /// <summary>
        /// 上一节点ID
        /// </summary>
        public string FRONT_NODE_ID
        {
            get { return _front_node_id; }
            set { _front_node_id = value; }
        }

        private string _node_result = "2";

        public static string FIELD_NODE_RESULT = "node_result";
        /// <summary>
        /// 当前节点审核结果，
        ///审核状态，字典项存储Audit_Status
        ///'1':已审核
        ///'2':未通过
        /// </summary>
        public string NODE_RESULT
        {
            get { return _node_result; }
            set { _node_result = value; }
        }

        private string _operation_remark;

        public static string FIELD_OPERATION_REMARK = "operation_remark";
        /// <summary>
        /// 操作意见
        /// </summary>
        public string OPERATION_REMARK
        {
            get { return _operation_remark; }
            set { _operation_remark = value; }
        }

        private string _operation_user;

        public static string FIELD_OPERATION_USER = "operation_user";
        /// <summary>
        /// 操作员用户名
        /// </summary>
        public string OPERATION_USER
        {
            get { return _operation_user; }
            set { _operation_user = value; }
        }

        public static string FIELD_OPERATION_TIME = "operation_time";
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OPERATION_TIME { get; set; }

        public static string FIELD_CURRENT_NODE_STATUS = "current_node_status";
        /// <summary>
        /// 当前节点的业务状态
        /// </summary>
        public string CURRENT_NODE_STATUS { get; set; }

    }
}
