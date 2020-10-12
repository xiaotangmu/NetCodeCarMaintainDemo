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
    /// 登录日志
    /// </summary>
    [Serializable]
    public class T_SYSTEM_LOGIN_LOG : BaseEntity
    {
        public static string TABLE_NAME = "t_system_login_log";

        private string _ip;

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private DateTime? _login_time;

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? LOGIN_TIME
        {
            get { return _login_time; }
            set { _login_time = value; }
        }

        private string _login_name;

        /// <summary>
        /// 登录用户
        /// </summary>
        public string LOGIN_NAME
        {
            get { return _login_name; }
            set { _login_name = value; }
        }

        private string _status;

        /// <summary>
        /// 登录状态
        /// 0：注销
        ///1：登录
        /// </summary>
        public string STATUS
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
