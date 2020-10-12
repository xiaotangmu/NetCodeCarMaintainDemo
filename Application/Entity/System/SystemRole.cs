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
    /// 系统角色
    /// </summary>
    [Serializable]
    public class T_SYSTEM_ROLE : BaseEntity
    {
        public static string TABLE_NAME = "t_system_role";

        private string _code;

        public static string FIELD_CODE = "code";
        /// <summary>
        /// 角色编码
        /// </summary>
        public string CODE
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _name;

        public static string FIELD_NAME = "name";
        /// <summary>
        /// 角色名称
        /// </summary>
        public string NAME
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _isuse;

        public static string FIELD_ISUSE = "isuse";
        /// <summary>
        /// 1：启用（默认）
        ///0：停用
        /// </summary>
        public string ISUSE
        {
            get { return _isuse; }
            set { _isuse = value; }
        }
        
        private static readonly string CONSTRAIN_AK_SYSTEM_ROLE_CODE = "ak_system_role_code";

        protected async override Task<Exception> ColumnContrainException(Exception ex)
        {
            System.Reflection.PropertyInfo ColumnNameProperty = ex.GetType().GetProperty("ColumnName");
            if (ColumnNameProperty == null || ColumnNameProperty.GetValue(ex) == null)
            {
                return ex;
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("角色編碼不能爲空"));
            }
            if (ColumnNameProperty.GetValue(ex).Equals(FIELD_NAME))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("角色名稱不能爲空"));
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
            if (contrainNameProperty.GetValue(ex).Equals(CONSTRAIN_AK_SYSTEM_ROLE_CODE))
            {
                return new Exception(await Localization.Localizer.GetValueAsync("角色編碼重複"));
            }
            return ex;
        }
    }
}
