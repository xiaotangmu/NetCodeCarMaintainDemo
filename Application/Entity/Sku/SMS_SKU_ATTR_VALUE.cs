using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.Sku
{
    public class SMS_SKU_ATTR_VALUE
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

        public SMS_SKU_ATTR_VALUE()
        {
            _id = Guid.NewGuid().ToString().Replace("-", "");
        }
        /// <summary>
        /// 库存编号
        /// </summary>
        public static readonly string FIELD_SKU_ID = "sku_id";
        public string SKU_ID { get; set; }

        /// <summary>
        /// 关联属性值
        /// </summary>
        public static readonly string FIELD_SPU_ATTR_VALUE_ID = "spu_attr_value_id";
        public string SPU_ATTR_VALUE_ID { get; set; }
    }
}
