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
    /// �û���ɫ������
    /// </summary>
    [Serializable]
    public class T_SYSTEM_USERROLE : BaseEntity
    {
        public static string TABLE_NAME = "t_system_userrole";

        private string _account;

        /// <summary>
        /// �û�ID
        /// </summary>
        public string ACCOUNT
        {
            get { return _account; }
            set { _account = value; }
        }

        private string _role_code;

        /// <summary>
        /// ��ɫID
        /// </summary>
        public string ROLE_CODE
        {
            get { return _role_code; }
            set { _role_code = value; }
        }
    }
}
