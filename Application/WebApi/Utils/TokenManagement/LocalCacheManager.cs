
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cache;

namespace WebApi.Utils.TokenManagement
{
    /// <summary>
    /// 本地缓存管理器（用于存储黑名单）
    /// </summary>
    public class LocalCacheManager : ITokenContainer
    {
        /// <summary>
        /// 本地缓存管理器
        /// </summary>
        public LocalCacheManager()
        {
        }

        public string GetValue(string key)
        {
            return CacheHelper.GetCache(key).ToString();
        }

        public bool IsExist(string key)
        {
            return CacheHelper.GetCache(key) != null ? true : false;
        }

        public bool Push(string key, string value, TimeSpan expireTime)
        {
            CacheHelper.SetCache(key, value, expireTime);
            return true;
        }

        public void Remove(string key)
        {
            if (IsExist(key))
            {
                CacheHelper.RemoveCache(key);
            }
        }
    }
}
