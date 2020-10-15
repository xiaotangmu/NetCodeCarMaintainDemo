using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.Catalog
{
    /// <summary>
    /// 二级分类表
    /// </summary>
    public class BMMS_CATALOG2: BaseEntity
    {
        /// <summary>
        /// 分类名
        /// </summary>
        public static readonly string FIELD_CATALOG_NAME = "catalog_name";
        public string CATALOG_NAME { get; set; }

        /// <summary>
        /// 一级分类id
        /// </summary>
        public static readonly string FIELD_PARENT_ID = "parent_id";
        public int PARENT_ID { get; set; }

    }
}
