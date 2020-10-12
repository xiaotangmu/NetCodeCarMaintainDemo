using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// ���ߣ�xavier
/// ���ڣ�2019-04-26 09:42:19
/// ������
/// </summary>

namespace Entity.Workflow
{
    /// <summary>
    /// ��˶���
    /// </summary>
    [Serializable]
    public class AUDIT_QUEUE : BaseEntity
    {
        private string _order_number;

        public static string FIELD_ORDER_NUMBER = "order_number";
        /// <summary>
        /// ���ݱ�ʶ
        /// </summary>
        public string ORDER_NUMBER
        {
            get { return _order_number; }
            set { _order_number = value; }
        }

        public static string FIELD_ORDER_TYPE = "order_type";
        /// <summary>
        /// ҵ������
        /// </summary>
        public string ORDER_TYPE { get; set; }

        private string _check_status;

        public static string FIELD_CHECK_STATUS = "check_status";
        /// <summary>
        /// ���״̬���ֵ���洢Audit_Status��Ĭ��'0'
        ///'0':�����
        ///'1':�����
        ///'2':δͨ��
        ///'3':δ�ύ���
        ///'99':�ѽ���
        /// </summary>
        public string CHECK_STATUS
        {
            get { return _check_status; }
            set { _check_status = value; }
        }

        private string _current_node_id;

        public static string FIELD_CURRENT_NODE_ID = "current_node_id";
        /// <summary>
        /// ��ǰ�ڵ�ID
        /// </summary>
        public string CURRENT_NODE_ID
        {
            get { return _current_node_id; }
            set { _current_node_id = value; }
        }

        private string _front_node_id;

        public static string FIELD_FRONT_NODE_ID = "front_node_id";
        /// <summary>
        /// ��һ�ڵ�ID
        /// </summary>
        public string FRONT_NODE_ID
        {
            get { return _front_node_id; }
            set { _front_node_id = value; }
        }

        private string _front_node_result;

        public static string FIELD_LAST_NODE_RESULT = "front_node_result";
        /// <summary>
        /// ��һ�ڵ���˽ڹ�
        /// </summary>
        public string FRONT_NODE_RESULT
        {
            get { return _front_node_result; }
            set { _front_node_result = value; }
        }

        private string _front_operate_remark;

        public static string FIELD_LAST_OPERATE_REMARK = "front_operate_remark";
        /// <summary>
        /// ��һ�ڵ�������
        /// </summary>
        public string FRONT_OPERATE_REMARK
        {
            get { return _front_operate_remark; }
            set { _front_operate_remark = value; }
        }

        private string _front_operate_id;

        public static string FIELD_LAST_OPERATE_ID = "front_operate_id";
        /// <summary>
        /// ��һ�ڵ����ԱID
        /// </summary>
        public string FRONT_OPERATE_ID
        {
            get { return _front_operate_id; }
            set { _front_operate_id = value; }
        }

        private DateTime? _front_operate_time;

        public static string FIELD_LAST_OPERATE_TIME = "front_operate_time";
        /// <summary>
        /// ��һ�ڵ����ʱ��
        /// </summary>
        public DateTime? FRONT_OPERATE_TIME
        {
            get { return _front_operate_time; }
            set { _front_operate_time = value; }
        }

        private string _apply_user;

        public static string FIELD_APPLY_USER = "apply_user";
        /// <summary>
        /// ������ID
        /// </summary>
        public string APPLY_USER
        {
            get { return _apply_user; }
            set { _apply_user = value; }
        }

        private DateTime _apply_time;

        public static string FIELD_APPLY_TIME = "apply_time";
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime APPLY_TIME
        {
            get { return _apply_time; }
            set { _apply_time = value; }
        }

        private string _lock_user;

        public static string FIELD_LOCK_USER = "lock_user";
        /// <summary>
        /// ������LOCK_USER
        /// </summary>
        public string LOCK_USER
        {
            get { return _lock_user; }
            set { _lock_user = value; }
        }

        private DateTime? _lock_time;

        public static string FIELD_LOCK_TIME = "lock_time";
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? LOCK_TIME
        {
            get { return _lock_time; }
            set { _lock_time = value; }
        }

        private int? _lock_status;

        public static string FIELD_LOCK_STATUS = "lock_status";
        /// <summary>
        /// ����״̬
        /// </summary>
        public int? LOCK_STATUS
        {
            get { return _lock_status; }
            set { _lock_status = value; }
        }

        public static string FIELD_CREATE_USER = "create_user";
        /// <summary>
        /// ������
        /// </summary>
        public string CREATE_USER { get; set; }

        public static string FIELD_MODIFY_USER = "modify_user";
        /// <summary>
        /// �޸���
        /// </summary>
        public string MODIFY_USER { get; set; }

        private string _remark1;

        /// <summary>
        /// ��ע1
        /// </summary>
        public string REMARK1
        {
            get { return _remark1; }
            set { _remark1 = value; }
        }

        private string _remark2;

        /// <summary>
        /// ��ע2
        /// </summary>
        public string REMARK2
        {
            get { return _remark2; }
            set { _remark2 = value; }
        }

        private static string CONSTRAIN_AK_AUDIT_QUEUE_ORDERID = "ak_audit_queue_orderid";

        protected async override Task<Exception> ColumnContrainException(Exception ex)
        {
            System.Reflection.PropertyInfo ColumnNameProperty = ex.GetType().GetProperty("ColumnName");
            if (ColumnNameProperty == null || ColumnNameProperty.GetValue(ex) == null)
            {
                return ex;
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_ORDER_NUMBER))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("�P�I�ղ��ܠ���"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_CHECK_STATUS))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("���ˠ�B���ܠ���"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_CURRENT_NODE_ID))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("��ǰ���c���ܠ���"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_APPLY_USER))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("��Ո�˲��ܠ���"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_APPLY_TIME))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("��Ո�r�g���ܠ���"));
            }
            return ex;
        }

        protected async override Task<Exception> UniqueContrainException(Exception ex)
        {
            System.Reflection.PropertyInfo contrainNameProperty = ex.GetType().GetProperty("ConstraintName");
            if (contrainNameProperty == null || contrainNameProperty.GetValue(ex) == null)
            {
                return ex;
            }
            if (contrainNameProperty.GetValue(ex).Equals(CONSTRAIN_AK_AUDIT_QUEUE_ORDERID))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("�I�Ն����}"));
            }
            return ex;
        }
    }
}
