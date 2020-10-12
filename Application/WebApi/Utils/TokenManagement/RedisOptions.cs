using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Utils.TokenManagement
{
    /// <summary>
    /// Redis参数选项类
    /// </summary>
    public class RedisOptions
    {
        /// <summary>
        /// 主机地址
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public string Port { get; set; }
    }
}
