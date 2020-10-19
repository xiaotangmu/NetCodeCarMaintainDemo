using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.Spu
{
    public class PMS_SPU_ATTR
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
        public PMS_SPU_ATTR()
        {
            _id = Guid.NewGuid().ToString().Replace("-", "");
        }

        /// <summary>
        /// 产品ID
        /// </summary>
        public static readonly string FIELD_SPU_ID = "spu_id";
        public string SPU_ID { get; set; }

        /// <summary>
        /// 分类属性ID
        /// </summary>
        public static readonly string FIELD_ATTR_ID = "attr_id";
        public string ATTR_ID { get; set; }
    }
}
