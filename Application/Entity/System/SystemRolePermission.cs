using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/// <summary>
/// 作者：xavier
/// 日期：2019-04-26 09:42:20
/// 描述：
/// </summary>

namespace Entity.Sys
{
    /// <summary>
    /// 系统角色权限
    /// </summary>
    [Serializable]
    public class T_SYSTEM_ROLE_PERMISSION : BaseEntity
    {
        public static string TABLE_NAME = "t_system_role_permission";

        private string _role_code;

        /// <summary>
        /// 角色ID
        /// </summary>
        public string ROLE_CODE
        {
            get { return _role_code; }
            set { _role_code = value; }
        }

        private string _permission_code;

        /// <summary>
        /// 权限ID
        /// </summary>
        public string PERMISSION_CODE
        {
            get { return _permission_code; }
            set { _permission_code = value; }
        }
    }
}
