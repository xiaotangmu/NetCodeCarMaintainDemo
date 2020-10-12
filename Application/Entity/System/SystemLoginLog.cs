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
    /// ��¼��־
    /// </summary>
    [Serializable]
    public class T_SYSTEM_LOGIN_LOG : BaseEntity
    {
        public static string TABLE_NAME = "t_system_login_log";

        private string _ip;

        /// <summary>
        /// IP��ַ
        /// </summary>
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private DateTime? _login_time;

        /// <summary>
        /// ��¼ʱ��
        /// </summary>
        public DateTime? LOGIN_TIME
        {
            get { return _login_time; }
            set { _login_time = value; }
        }

        private string _login_name;

        /// <summary>
        /// ��¼�û�
        /// </summary>
        public string LOGIN_NAME
        {
            get { return _login_name; }
            set { _login_name = value; }
        }

        private string _status;

        /// <summary>
        /// ��¼״̬
        /// 0��ע��
        ///1����¼
        /// </summary>
        public string STATUS
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
