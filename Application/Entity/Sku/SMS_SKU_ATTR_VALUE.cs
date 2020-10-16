using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.Sku
{
    public class SMS_SKU_ATTR_VALUE
    {
        /// <summary>
        /// 属性编号
        /// </summary>
        public static readonly string FIELD_ATTR_NO = "sku_no";
        public string SKU_NO { get; set; }

        /// <summary>
        /// 库存编号
        /// </summary>
        public static readonly string FIELD_SKU_ID = "sku_id";
        public string SKU_ID { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        public static readonly string FIELD_VALUE = "value";
        public string VALUE { get; set; }
    }
}
