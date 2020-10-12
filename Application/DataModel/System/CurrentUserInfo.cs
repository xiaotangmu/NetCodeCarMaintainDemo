using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.System
{
    /// <summary>
    /// 当前登录的用户信息
    /// </summary>
    public class CurrentUserInfo
    {
        public string Account { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 用戶類型，1：一般用戶；2：遊客
        /// </summary>
        public UserType UserType { get; set; }
    }
}
