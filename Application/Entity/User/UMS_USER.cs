using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.User
{
    public class UMS_USER : BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public static readonly string FIELD_USER_NAME = "user_name";
        public string USER_NAME { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public static readonly string FIELD_PWD = "pwd";
        public string PWD { get; set; }

        /// <summary>
        /// 盐值
        /// </summary>
        public static readonly string FIELD_SALT = "salt";
        public string SALT { get; set; }
    }
}
