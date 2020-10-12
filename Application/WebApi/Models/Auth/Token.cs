using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Auth
{
    /// <summary>
    /// 请求令牌
    /// </summary>
    public class Token
    {
        /// <summary>
        /// token字符串
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 过期时差
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// 用于刷新Token的令牌
        /// </summary>
        public string reflesh_token { get; set; }

        /// <summary>
        /// reflesh_token的过期时间，相对expires_in周期长的多
        /// </summary>
        public int re_expires { get; set; }

        /// <summary>
        /// 当前登录用户ID
        /// </summary>
        public string current_user { get; set; }
    }
}
