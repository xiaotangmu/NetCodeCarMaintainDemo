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
    /// 操作日志
    /// </summary>
    [Serializable]
    public class T_SYSTEM_OPERATION_LOG : BaseEntity
    {
        public static string TABLE_NAME = "t_system_operation_log";

        private string _login_name;

        /// <summary>
        /// 登录用户
        /// </summary>
        public string LOGIN_NAME
        {
            get { return _login_name; }
            set { _login_name = value; }
        }

        private DateTime? _operation_time;

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OPERATION_TIME
        {
            get { return _operation_time; }
            set { _operation_time = value; }
        }

        private string _content;

        /// <summary>
        /// 操作内容
        /// </summary>
        public string CONTENT
        {
            get { return _content; }
            set { _content = value; }
        }

        private string _url;

        /// <summary>
        /// 请求访问路径
        /// </summary>
        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _url_args;

        /// <summary>
        /// 请求访问参数
        /// </summary>
        public string URL_ARGS
        {
            get { return _url_args; }
            set { _url_args = value; }
        }
    }
}
