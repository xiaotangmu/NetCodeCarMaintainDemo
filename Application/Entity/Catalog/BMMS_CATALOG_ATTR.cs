using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.Catalog
{
    /// <summary>
    /// 分类属性表
    /// </summary>
    public class BMMS_CATALOG_ATTR: BaseEntity
    {
        /// <summary>
        /// 属性名
        /// </summary>
        public static readonly string FIELD_ATTR_NAME = "attr_name";
        public string ATTR_NAME { get; set; }

        /// <summary>
        /// 二级分类
        /// </summary>
        public static readonly string FIELD_CATALOG_ID = "catalog_id";
        public string CATALOG_ID { get; set; }
    }
}
