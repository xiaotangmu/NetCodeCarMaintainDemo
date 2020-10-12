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
    /// 系统字典
    /// </summary>
    [Serializable]
    public class T_SYSTEM_DICT : BaseEntity
    {
        public static string TABLE_NAME = "t_system_dict";

        private string _code;
        public static string FIELD_CODE = "code";
        /// <summary>
        /// 字典编码
        /// </summary>
        public string CODE
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _type_code;
        public static string FIELD_TYPE_CODE = "type_code";
        /// <summary>
        /// 类型编码
        /// </summary>
        public string TYPE_CODE
        {
            get { return _type_code; }
            set { _type_code = value; }
        }

        private string _text;
        public static string FIELD_TEXT = "text";
        /// <summary>
        /// 字典文本
        /// </summary>
        public string TEXT
        {
            get { return _text; }
            set { _text = value; }
        }

        private string _isleaf = "0";

        /// <summary>
        /// 1：是叶子节点
        ///0：不是叶子节点（默认）
        /// </summary>
        public string ISLEAF
        {
            get { return _isleaf; }
            set { _isleaf = value; }
        }

        private int? _sort_number;

        /// <summary>
        /// 排序号
        /// </summary>
        public int? SORT_NUMBER
        {
            get { return _sort_number; }
            set { _sort_number = value; }
        }

        private string _isuse;

        /// <summary>
        /// 是否启用
        /// 1：启用（默认）
        /// 0：停用
        /// </summary>
        public string ISUSE
        {
            get { return _isuse; }
            set { _isuse = value; }
        }

        private string _isdelete;

        /// <summary>
        /// 是否删除
        /// 1：删除
        /// 0：未删除（默认）
        /// </summary>
        public string ISDELETE
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }

        private string _description;

        /// <summary>
        /// 描述
        /// </summary>
        public string DESCRIPTION
        {
            get { return _description; }
            set { _description = value; }
        }

        private static string CONSTRAIN_AK_SYSTEM_DICT_CODE = "ak_system_dict_code";

        protected async override Task<Exception> ColumnContrainException(Exception ex)
        {
            System.Reflection.PropertyInfo ColumnNameProperty = ex.GetType().GetProperty("ColumnName");
            if (ColumnNameProperty == null || ColumnNameProperty.GetValue(ex) == null)
            {
                return ex;
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("編碼不能爲空"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_TEXT))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("名稱不能爲空"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_TYPE_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("類型不能爲空"));
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
            if (contrainNameProperty.GetValue(ex).Equals(CONSTRAIN_AK_SYSTEM_DICT_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("編碼重複"));
            }
            return ex;
        }
    }
}
