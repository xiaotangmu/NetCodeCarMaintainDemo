using Entity;
using System;

namespace DateModel.Sku
{
    /// <summary>
    /// 库存模块下的入库表
    /// </summary>
    public class SMS_ENTRY : BaseEntity
    {
        public static readonly string FIELD_ENTRY_NO = "entry_no";
        public string ENTRY_NO { get; set; }
        public static readonly string FIELD_OPERATOR = "operator";
        public string OPERATOR { get; set; }
        public static readonly string FIELD_TOTAL_PRICE = "total_price";
        public decimal TOTAL_PRICE { get; set; }
        public static readonly string FIELD_ENTRY_DATE = "entry_date";
        public DateTime ENTRY_DATE { get; set; }
        public static readonly string FIELD_BATCH = "batch";
        public int BATCH { get; set; }
        public static readonly string FIELD_SUPPLIER_ID = "supplier_id";
        public string SUPPLIER_ID { get; set; }
        public static readonly string FIELD_DESCRIPTION = "description";
        public string DESCRIPTION { get; set; }
        public static readonly string FIELD_IS_MAINTAIN = "is_maintain";
        public int IS_MAINTAIN { get; set; }
        public static readonly string FIELD_MAINTAIN_ID = "maintain_id";
        public string MAINTAIN_ID { get; set; }
    }
}
