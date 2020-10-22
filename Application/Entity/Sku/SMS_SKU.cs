using Entity;
using System;

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
        /// 关联spu
        /// </summary>
        public static readonly string FIELD_SPU_ID = "spu_id";
        public string SPU_ID { get; set; }

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
        public static readonly string FIELD_TOTAL_COUNT = "total_count";
        public int TOTAL_COUNT { get; set; }

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
        /// 是否是工具，0为配件，1为工具，工具出库不作库存报警
        /// </summary>
        public static readonly string FIELD_TYPE = "type";
        public int TOOL { get; set; }

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

        /// <summary>
        /// 所属分类
        /// </summary>
        public static readonly string FIELD_CATALOG2_ID = "catalog2_id";
        public string CATALOG2_ID { get; set; }
    }

    public class SMS_SKU_ADDRESS
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

        public SMS_SKU_ADDRESS()
        {
            _id = Guid.NewGuid().ToString().Replace("-", "");
        }

        /// <summary>
        /// 管理库存
        /// </summary>
        public static readonly string FIELD_SKU_ID = "sku_id";
        public string SKU_ID { get; set; }

        /// <summary>
        /// 房间号
        /// </summary>
        public static readonly string FIELD_ROOM = "room";
        public string ROOM { get; set; }

        /// <summary>
        /// 货架号
        /// </summary>
        public static readonly string FIELD_SELF = "self";
        public string SELF { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public static readonly string FIELD_QUANTITY = "quantity";
        public int QUANTITY { get; set; }
    }
}
