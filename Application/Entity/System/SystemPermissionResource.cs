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
    /// 资源权限
    /// </summary>
    [Serializable]
    public class T_SYSTEM_PERMISSION_RESOURCE :BaseEntity
    {
        public static string TABLE_NAME = "t_system_permission_resource";

        private string _resource_code;

        /// <summary>
        /// 资源ID
        /// </summary>
        public string RESOURCE_CODE
        {
          get { return _resource_code;}
          set { _resource_code=value;}
        }

        private string _permission_code;

        /// <summary>
        /// 权限ID
        /// </summary>
        public string PERMISSION_CODE
        {
          get { return _permission_code; }
          set { _permission_code = value;}
        }
    }
}
