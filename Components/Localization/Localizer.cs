using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Localization
{
    /// <summary>
    /// 全球化帮助类
    /// </summary>
    public class Localizer
    {
        private static IMemoryCache _memory;
        private static CultureInfo _currentCulture;

        private Localizer()
        {
        }

        public static void Init(CultureInfo culture)
        {
            //暂未需对缓存作约束
            _memory = new MemoryCache(new MemoryCacheOptions());
            _currentCulture = culture;
        }

        public static async Task<string> GetValueAsync(string key)
        {
            ConcurrentDictionary<string, string> resource = await GetCultureSource(); //await CultureHelper.GetResourceNames(Thread.CurrentThread.CurrentCulture.Name);
            if (resource == null)
            {
                return key;
            }
            if (resource.ContainsKey(key))
            {
                return resource[key];
            }
            else
            {
                return key;
            }
        }

        public static CultureInfo GetCurrentCulture()
        {
            return _currentCulture;
        }

        private static async Task<ConcurrentDictionary<string, string>> GetCultureSource()
        {
            ConcurrentDictionary<string, string> resource = new ConcurrentDictionary<string, string>();
            if (_memory == null)
            {
                _memory = new MemoryCache(new MemoryCacheOptions());
            }
            if (_currentCulture == null)
            {
                _currentCulture = Thread.CurrentThread.CurrentCulture;
            }
            //试图从内存缓存取资源
            if (_memory.TryGetValue(_currentCulture.Name, out resource))
            {
                return resource;
            }
            //内存不存在资源则从磁盘文件中读取，并缓存到内存中
            resource = await CultureHelper.GetResourceNames(_currentCulture.Name);
            _memory.CreateEntry(_currentCulture.Name).Value = resource;

            return resource;
        }
    }
}
