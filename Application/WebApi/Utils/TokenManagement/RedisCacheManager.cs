using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Utils.TokenManagement
{
    /// <summary>
    /// Redis缓存管理器（用于存储黑名单的另一种策略）
    /// </summary>
    public class RedisCacheManager : ITokenContainer
    {
        private RedisOptions _options;

        /// <summary>
        /// Redis缓存管理器
        /// </summary>
        /// <param name="option">Redis参数选项类实例</param>
        public RedisCacheManager(RedisOptions option)
        {
            _options = option;
        }

        public string GetValue(string key)
        {
            using (var redis = new RedisClient(_options.Host, _options.Port))
            {
                return redis.Get<string>(key);
            }
        }

        public bool IsExist(string key)
        {
            using (var redis = new RedisClient(_options.Host, _options.Port))
            {
                return redis.IsExists(key);
            }
        }

        public bool Push(string key, string value, TimeSpan expireTime)
        {
            using (var redis = new RedisClient(_options.Host, _options.Port))
            {
                return redis.StoreAsync(key, value, DateTime.UtcNow.Add(expireTime));
            }
        }

        public void Remove(string key)
        {
            using (var redis = new RedisClient(_options.Host, _options.Port))
            {
                if (redis.IsExists(key))
                {
                    redis.Remove<string>(key);
                }
            }
        }
    }
}
