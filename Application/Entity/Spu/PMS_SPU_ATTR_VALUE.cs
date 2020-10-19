using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.Spu
{
    public class PMS_SPU_ATTR_VALUE
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
        public PMS_SPU_ATTR_VALUE()
        {
            _id = Guid.NewGuid().ToString().Replace("-", "");
        }
        /// <summary>
        /// 产品属性ID
        /// </summary>
        public static readonly string FIELD_SPU_ATTR_ID = "spu_attr_id";
        public string SPU_ATTR_ID { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        public static readonly string FIELD_VALUE = "value";
        public string VALUE { get; set; }

    }
}
