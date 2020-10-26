using Entity;

namespace DateModel.Maintain
{
    /// <summary>
    /// 预约单
    /// </summary>
    public class MMS_APPOINTMENT : BaseEntity
    {
        /// <summary>
        /// 预约编号
        /// </summary>
        public static readonly string FIELD_APPOINTMENT_NO = "appointment_no";
        public string APPOINTMENT_NO { get; set; }
        /// <summary>
        /// 客户公司
        /// </summary>
        public static readonly string FIELD_COMPANY_ID = "company_id";
        public string COMPANY_ID { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public static readonly string FIELD_CAR_LICENSE = "car_license";
        public string CAR_LICENSE { get; set; }
        /// <summary>
        /// 问题描述
        /// </summary>
        public static readonly string FIELD_DESCRIPTION = "description";
        public string DESCRIPTION { get; set; }
        /// <summary>
        /// 预约日期
        /// </summary>
        public static readonly string FIELD_APPOINTMENT_DATE = "appointment_date";
        public string APPOINTMENT_Date { get; set; }
        /// <summary>
        /// 车型
        /// </summary>
        public static readonly string FIELD_TYPE = "type";
        public string TYPE { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public static readonly string FIELD_PHONE = "phone";
        public string PHONE { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public static readonly string FIELD_CONTACT = "contact";
        public string CONTACT { get; set; }
        /// <summary>
        /// 是否取消，0未处理，1处理，2取消
        /// </summary>
        public static readonly string FIELD_STATUS = "status";
        public string STATUS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string FIELD_REMARK = "remark";
        public string REMARK { get; set; }
    }
}
