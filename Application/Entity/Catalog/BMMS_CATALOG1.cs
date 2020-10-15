using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.Catalog
{
    /// <summary>
    /// 基本信息模块表: 一级分类
    /// </summary>
    public class BMMS_CATALOG1: BaseEntity
    {
        /// <summary>
        /// 分类名
        /// </summary>
        public static readonly string FIELD_CATALOG_NAME = "catalog_name";
        public string CATALOG_NAME { get; set; }

    }

}
