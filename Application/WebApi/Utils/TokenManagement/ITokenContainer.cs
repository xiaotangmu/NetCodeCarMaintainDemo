using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Utils.TokenManagement
{
    /// <summary>
    /// Token容器接口
    /// </summary>
    public interface ITokenContainer
    {
        /// <summary>
        /// 推进
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        /// <param name="expireTime">过期时间</param>
        /// <returns></returns>
        bool Push(string key, string value, TimeSpan expireTime);

        /// <summary>
        /// 取值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        string GetValue(string key);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key">目标Token</param>
        /// <returns></returns>
        bool IsExist(string key);

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        void Remove(string key);
    }
}
