using Entity;
using System;

namespace DateModel.Sku
{
    /// <summary>
    /// </summary>
    public class SMS_CHECK : BaseEntity
    {
        public static readonly string FIELD_CHECK_NO = "check_no";
        public string CHECK_NO { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public static readonly string FIELD_OPERATOR = "operator";
        public string OPERATOR { get; set; }
        /// <summary>
        /// 盘点日期
        /// </summary>
        public static readonly string FIELD_CHECK_DATE = "check_date";
        public DateTime CHECK_DATE { get; set; }
        /// <summary>
        /// 账面总金额
        /// </summary>
        public static readonly string FIELD_ACCOUNT_PRICE = "account_price";
        public decimal ACCOUNT_PRICE { get; set; }
        /// <summary>
        /// 盘点总金额
        /// </summary>
        public static readonly string FIELD_CHECK_PRICE = "check_price";
        public decimal CHECK_PRICE { get; set; }
        /// <summary>
        /// 相差总金额, 正多，负少
        /// </summary>
        public static readonly string FIELD_DIFFERENCE_PRICE = "difference_price";
        public decimal DIFFERENCE_PRICE { get; set; }
        /// <summary>
        /// 是否已经处理，0处理，1未处理
        /// </summary>
        public static readonly string FIELD_STATUS = "status";
        public int STATUS { get; set; }
        public static readonly string FIELD_DESCRIPTION = "description";
        public string DESCRIPTION { get; set; }
    }
}
