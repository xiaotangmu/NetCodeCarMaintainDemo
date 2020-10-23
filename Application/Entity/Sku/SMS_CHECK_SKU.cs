using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.Sku
{
    public class SMS_CHECK_SKU
    {
        /// <summary>
        /// 表ID
        /// </summary>
        private string _id;

        /// <summary>
        /// 表ID
        /// </summary>
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public SMS_CHECK_SKU()
        {
            _id = Guid.NewGuid().ToString().Replace("-", "");
        }
        /// <summary>
        /// 关联盘点单
        /// </summary>
        public static readonly string FIELD_CHECK_ID = "check_id";
        public string CHECK_ID { get; set; }
        /// <summary>
        /// 关联库存（位置）
        /// </summary>
        public static readonly string FIELD_ADDRESS_ID = "address_id";
        public string ADDRESS_ID { get; set; }
        /// <summary>
        /// 盘点数量
        /// </summary>
        public static readonly string FIELD_CHECK_NUM = "check_num";
        public int CHECK_NUM { get; set; }
        /// <summary>
        /// 盘点总金额
        /// </summary>
        public static readonly string FIELD_CHECK_PRICE = "check_price";
        public decimal CHECK_PRICE { get; set; }
        /// <summary>
        /// 当时单价
        /// </summary>
        public static readonly string FIELD_PRICE = "price";
        public decimal PRICE { get; set; }
        /// <summary>
        /// 账面总金额
        /// </summary>
        public static readonly string FIELD_ACCOUNT_PRICE = "account_price";
        public decimal ACCOUNT_PRICE { get; set; }
        /// <summary>
        /// 账面数量
        /// </summary>
        public static readonly string FIELD_ACCOUNT_NUM = "account_num";
        public int ACCOUNT_NUM { get; set; }
        /// <summary>
        /// 相差数量，正多，负少
        /// </summary>
        public static readonly string FIELD_DIFFERENCE_NUM = "difference_num";
        public int DIFFERENCE_NUM { get; set; }
        /// <summary>
        /// 相差总金额，正多，负少
        /// </summary>
        public static readonly string FIELD_DIFFERENCE_PRICE = "difference_price";
        public decimal DIFFERENCE_PRICE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string FIELD_DESCRIPTION = "description";
        public string DESCRIPTION { get; set; }
        /// <summary>
        /// 是否处理，1已经处理，0没有处理
        /// </summary>
        public static readonly string FIELD_STATUS = "status";
        public int STATUS { get; set; }

    }
}
