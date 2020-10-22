using Entity;
using System;

namespace DateModel.Sku
{
    /// <summary>
    /// 出库表
    /// </summary>
    public class SMS_OUT : BaseEntity
    {
        public static readonly string FIELD_OUT_NO = "out_no";
        public string OUT_NO { get; set; }
        public static readonly string FIELD_OPERATOR = "operator";
        public string OPERATOR { get; set; }
        public static readonly string FIELD_OUT_DATE = "out_date";
        public DateTime OUT_DATE { get; set; }
        public static readonly string FIELD_TOTAL_PRICE = "total_price";
        public decimal TOTAL_PRICE { get; set; }
        public static readonly string FIELD_BATCH = "batch";
        public int BATCH { get; set; }
        public static readonly string FIELD_DESCRIPTION = "description";
        public string DESCRIPTION { get; set; }
        public static readonly string FIELD_CLIENT_ID = "client_id";
        public string CLIENT_ID { get; set; }
    }
}
