using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// ���ߣ�xavier
/// ���ڣ�2019-04-26 09:42:20
/// ������
/// </summary>

namespace Entity.Sys
{
    /// <summary>
    /// ϵͳ�û�
    /// </summary>
    [Serializable]
    public class T_SYSTEM_USER : BaseEntity
    {
        public static string TABLE_NAME = "t_system_user";

        private string _account;

        public static string FIELD_ACCOUNT = "account";
        /// <summary>
        /// �û��˺�
        /// </summary>
        public string ACCOUNT
        {
            get { return _account; }
            set { _account = value; }
        }

        private string _name;

        public static string FIELD_NAME = "name";
        /// <summary>
        /// �û�����
        /// </summary>
        public string NAME
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _isuse = "1";

        public static string FIELD_ISUSE = "isuse";
        /// <summary>
        /// 1�����ã�Ĭ�ϣ�
        ///0��ͣ��
        /// </summary>
        public string ISUSE
        {
            get { return _isuse; }
            set { _isuse = value; }
        }
    }
}
