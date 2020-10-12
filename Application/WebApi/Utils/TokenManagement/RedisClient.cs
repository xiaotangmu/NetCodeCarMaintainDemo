using Microsoft.Extensions.Configuration;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Utils.TokenManagement
{
    /// <summary>
    /// Redis客户端
    /// </summary>
    public class RedisClient : IDisposable
    {
        private RedisManagerPool redisPool;
        private IRedisClient redis;

        /// <summary>
        /// 新建一个Redis客户端
        /// </summary>
        /// <param name="host">目标主机</param>
        /// <param name="port">端口</param>
        public RedisClient(string host, string port)
        {
            int.TryParse(port, out int changedPort);
            CreateClient(host, changedPort);
        }

        private void CreateClient(string host, int port)
        {
            string connectionString = string.Format("{0}:{1}", host, port);
            using (redisPool = new RedisManagerPool(connectionString))
            {
                redis = redisPool.GetClient();
            }
        }

        public T Get<T>(string key)
        {
            if (!redis.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }
            return redis.Get<T>(key);
        }

        public bool StoreAsync<T>(string key, T value, DateTime expireTime)
        {
            if (redis == null)
            {
                return false;
            }
            if (redis.ContainsKey(key))
            {
                return false;
            }
            return redis.Add(key, value, expireTime);
        }

        public void Remove<T>(string key)
        {
            if (redis.ContainsKey(key))
            {
                redis.Remove(key);
            }
        }

        public async Task RemoveAsync<T>(string key)
        {
            if (redis.ContainsKey(key))
            {
                await Task.Run(() => redis.Remove(key));
            }
        }

        public bool IsExists(string key)
        {
            return redis.ContainsKey(key);
        }

        public void Dispose()
        {
            redis.Dispose();
            redisPool.Dispose();
        }
    }

    [Serializable]
    internal class RedisKeyExistedException : Exception
    {
        public RedisKeyExistedException()
        {
        }

        public RedisKeyExistedException(string message) : base(message)
        {
        }

        public RedisKeyExistedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RedisKeyExistedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
