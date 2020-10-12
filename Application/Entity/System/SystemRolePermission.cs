using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/// <summary>
/// ���ߣ�xavier
/// ���ڣ�2019-04-26 09:42:20
/// ������
/// </summary>

namespace Entity.Sys
{
    /// <summary>
    /// ϵͳ��ɫȨ��
    /// </summary>
    [Serializable]
    public class T_SYSTEM_ROLE_PERMISSION : BaseEntity
    {
        public static string TABLE_NAME = "t_system_role_permission";

        private string _role_code;

        /// <summary>
        /// ��ɫID
        /// </summary>
        public string ROLE_CODE
        {
            get { return _role_code; }
            set { _role_code = value; }
        }

        private string _permission_code;

        /// <summary>
        /// Ȩ��ID
        /// </summary>
        public string PERMISSION_CODE
        {
            get { return _permission_code; }
            set { _permission_code = value; }
        }
    }
}
