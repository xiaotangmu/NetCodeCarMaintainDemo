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
    /// 用户角色关联表
    /// </summary>
    [Serializable]
    public class T_SYSTEM_USERROLE : BaseEntity
    {
        public static string TABLE_NAME = "t_system_userrole";

        private string _account;

        /// <summary>
        /// 用户ID
        /// </summary>
        public string ACCOUNT
        {
            get { return _account; }
            set { _account = value; }
        }

        private string _role_code;

        /// <summary>
        /// 角色ID
        /// </summary>
        public string ROLE_CODE
        {
            get { return _role_code; }
            set { _role_code = value; }
        }
    }
}
