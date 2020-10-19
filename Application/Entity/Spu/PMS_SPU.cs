using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.Spu
{
    public class PMS_SPU: BaseEntity
    {
        /// <summary>
        /// 关联二级分类
        /// </summary>
        public static readonly string FIELD_CATALOG2_ID = "catalog2_id";
        public string CATALOG2_ID { get; set; }

        /// <summary>
        /// 产品名
        /// </summary>
        public static readonly string FIELD_PRODUCT_NAME = "product_name";
        public string PRODUCT_NAME { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        public static readonly string FIELD_DESCRIPTION = "description";
        public string DESCRIPTION { get; set; }
    }
}
