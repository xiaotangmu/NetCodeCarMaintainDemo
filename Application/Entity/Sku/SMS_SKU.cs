using Entity;

namespace DateModel.Sku
{
    /// <summary>
    /// 库存表
    /// </summary>
    public class SMS_SKU : BaseEntity
    {
        /// <summary>
        /// 库存编号
        /// </summary>
        public static readonly string FIELD_SKU_NO = "sku_no";
        public string SKU_NO { get; set; }

        /// <summary>
        /// 库存名
        /// </summary>
        public static readonly string FIELD_SKU_NAME = "sku_name";
        public string SKU_NAME { get; set; }

        /// <summary>
        /// 库存存放房间号
        /// </summary>
        public static readonly string FIELD_ROOM = "room";
        public string ROOM { get; set; }

        /// <summary>
        /// 库存存放架子
        /// </summary>
        public static readonly string FIELD_SELF = "self";
        public string SELF { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public static readonly string FIELD_BRAND = "brand";
        public string BRAND { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public static readonly string FIELD_PRICE = "price";
        public decimal PRICE { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public static readonly string FIELD_UNIT = "unit";
        public string UNIT { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public static readonly string FIELD_QUANTITY = "quantity";
        public int QUANTITY { get; set; }

        /// <summary>
        /// 警报值
        /// </summary>
        public static readonly string FIELD_ALARM = "alarm";
        public int ALARM { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public static readonly string FIELD_DESCRIPTION = "description";
        public string DESCRIPTION { get; set; }

        /// <summary>
        /// 类型/规格
        /// </summary>
        public static readonly string FIELD_TYPE = "type";
        public string TYPE { get; set; }

        /// <summary>
        /// 状态，0为新（默认），1为旧
        /// </summary>
        public static readonly string FIELD_STATUS = "status";
        public int STATUS { get; set; }

        /// <summary>
        /// 如果为旧，关联旧配件表ID
        /// </summary>
        public static readonly string FIELD_OLD_PARTID = "old_partId";
        public string OLD_PARTID { get; set; }
    }
}
