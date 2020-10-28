using Entity;
using System;

namespace DateModel.Maintain
{

    public class MMS_MAINTAIN : BaseEntity
    {
        public static readonly string FIELD_MAINTAIN_NO = "maintain_no";
        public string MAINTAIN_NO { get; set; }
        public static readonly string FIELD_STAFF = "staff";
        public string STAFF { get; set; }
        public static readonly string FIELD_APPOINTMENT_ID = "appointment_id";
        public string APPOINTMENT_ID { get; set; }
        public static readonly string FIELD_START_DATE = "start_date";
        public DateTime START_DATE { get; set; }
        /// <summary>
        /// 是否已经签字完成，0没有，1处理完，2维修取消
        /// </summary>
        public static readonly string FIELD_STATUS = "status";
        public int STATUS { get; set; }
        public static readonly string FIELD_RETURN_DATE = "return_date";
        public DateTime RETURN_DATE { get; set; }
        public static readonly string FIELD_OPERATOR = "operator";
        public string OPERATOR { get; set; }
    }
}
