using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 作者：xavier
/// 日期：2019-04-26 09:42:20
/// 描述：
/// </summary>

namespace Entity.Sys
{
    /// <summary>
    /// 系统资源
    /// </summary>
    [Serializable]
    public class T_SYSTEM_RESOURCE : BaseEntity
    {
        public static string TABLE_NAME = "t_system_resource";

        private string _code;

        public static string FIELD_CODE = "code";
        /// <summary>
        /// 资源编码
        /// </summary>
        public string CODE
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _name;

        public static string FIELD_NAME = "name";
        /// <summary>
        /// 资源名称
        /// </summary>
        public string NAME
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _parent_id;

        public static string FIELD_PARENT_CODE = "parent_code";
        /// <summary>
        /// 父级编码
        /// </summary>
        public string PARENT_CODE
        {
            get { return _parent_id; }
            set { _parent_id = value; }
        }

        private string _url;

        public static string FIELD_URL = "url";
        /// <summary>
        /// 资源路径
        /// </summary>
        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _type;

        public static string FIELD_TYPE = "type";
        /// <summary>
        /// 0：分类
        ///1：菜单
        ///2：api
        /// </summary>
        public string TYPE
        {
            get { return _type; }
            set { _type = value; }
        }

        private int? _sort_num;

        public static string FIELD_SORT_NUM = "sort_num";
        /// <summary>
        /// 排序号
        /// </summary>
        public int? SORT_NUM
        {
            get { return _sort_num; }
            set { _sort_num = value; }
        }

        private int _defaultLevel = 0;
        public static string FIELD_LEVEL = "level";
        public int? LEVEL
        {
            get
            {
                return _defaultLevel;
            }
            set
            {
                _defaultLevel = (int)value;
            }
        }


        private static readonly string CONSTRAIN_AK_SYSTEM_RESOURCE_CODE = "ak_system_resource_code";

        protected async override Task<Exception> ColumnContrainException(Exception ex)
        {
            System.Reflection.PropertyInfo ColumnNameProperty = ex.GetType().GetProperty("ColumnName");
            if (ColumnNameProperty == null || ColumnNameProperty.GetValue(ex) == null)
            {
                return ex;
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("部門編碼不能爲空"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_PARENT_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("父級編碼不能爲空"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_TYPE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("資源類型不能爲空"));
            }
            return ex;
        }

        protected async override Task<Exception> UniqueContrainException(Exception ex)
        {
            System.Reflection.PropertyInfo contrainNameProperty = ex.GetType().GetProperty("ConstraintName");
            if (contrainNameProperty == null || contrainNameProperty.GetValue(ex) == null)
            {
                return ex;
            }
            if (contrainNameProperty.GetValue(ex).Equals(CONSTRAIN_AK_SYSTEM_RESOURCE_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("資源編碼重複"));
            }
            return ex;
        }
    }
}
