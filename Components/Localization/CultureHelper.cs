using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Localization
{
    /// <summary>
    ///  区域特性帮助类
    /// </summary>
    public class CultureHelper
    {
        public static ResourceManager LanguageResources { get; } = new ResourceManager("Localization.Resources.Language", Assembly.GetExecutingAssembly());

        public static IList<Culture> Cultures { get; } = new List<Culture> {
                new Culture{
                     Code = "zh-CN",
                     Name = "简体中文"
                },
                new Culture{
                     Code = "zh-MO",
                     Name = "繁體中文"
                },
                new Culture{
                     Code = "en-GB",
                     Name = "English"
                },
                new Culture{
                     Code = "pt-PT",
                     Name = "Português"
                }
        };
        //区域特性字典，也存储系统不支持，但同属一个语言系的区域特性
        //例如，系统不支持en-US，则取前两个字符en作为前缀，与系统支持的区域特性比较，如果有匹配的上则写入字典，否则写入默认的zh作为字典
        private static readonly ConcurrentDictionary<string, string> _getImplementedCultureCache = new ConcurrentDictionary<string, string>();

        private static ConcurrentDictionary<string, ConcurrentDictionary<string, string>> _resources = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();

        public async static Task<ConcurrentDictionary<string, object>> InitializeLanguageResource()
        {
            ConcurrentDictionary<string, object> result = new ConcurrentDictionary<string, object>();
            foreach (Culture culture in Cultures)
            {
                result.GetOrAdd(culture.Name, null);
            }
            //一次性把初始化的语言资源文件响应
            result[Cultures[0].Name] = await GetResourceNames(Cultures[0].Code);
            return result;
        }

        /// <summary>
        /// 根据名称获取实现的区域特性
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetImplementedCulture(string name = "")
        {
            if (string.IsNullOrEmpty(name))
            {
                return GetDefaultCulture(); // 如果为空，返回默认的区域特性
            }
            if (_getImplementedCultureCache.ContainsKey(name))
            {
                return _getImplementedCultureCache[name];   // 获取已经添加到字典的区域特性
            }
            if (Cultures.Any(c => c.Code.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            {
                return CacheCulture(name, name); // the culture is in our supported list, accept it
            }

            // 前缀匹配， 只进行语言特性匹配，不做区域特性匹配, 例如 en-AU == en-US ，只匹配前缀.
            var n = GetNeutralCulture(name);
            foreach (var c in Cultures)
            {
                if (c.Code.StartsWith(n))
                {
                    return CacheCulture(name, c.Code);
                }
            }
            return CacheCulture(name, GetDefaultCulture()); // return Default culture as no match found
        }

        /// <summary>
        /// 获取默认的区域特性
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultCulture()
        {
            return Cultures[0].Code; // return Default culture
        }

        /// <summary>
        /// 获取当前的区域特性
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }

        /// <summary>
        /// 获取当前的自然区域特性（只保留前两个字符）
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentNeutralCulture()
        {
            return GetNeutralCulture(Thread.CurrentThread.CurrentCulture.Name);
        }

        public static string GetNeutralCulture(string name)
        {
            if (name.Length <= 2)
            {
                return name;
            }
            return name.Substring(0, 2); // Read first two chars only. E.g. "en", "es"
        }

        /// <summary>
        /// 用于多语言装换
        /// 将ResourceManager 装换成Dictionary 
        /// </summary>
        /// <param name="strLang"></param>
        /// <returns></returns>
        public async static Task<ConcurrentDictionary<string, string>> GetResourceNames(string strLang)
        {
            string lang = GetImplementedCulture(strLang);
            //lang = (string.IsNullOrEmpty(strLang) || strLang.Equals("zh") || strLang.Equals("zh-CN")) ? "" : strLang;
            ConcurrentDictionary<string, string> currentLanguageResource = new ConcurrentDictionary<string, string>();
            if (_resources.ContainsKey(strLang))
            {
                currentLanguageResource = _resources[strLang];
                if (currentLanguageResource.Count <= 0)
                {
                    currentLanguageResource = await GetResourceDictionary(lang);
                    _resources[strLang] = currentLanguageResource;
                }
            }
            else
            {
                currentLanguageResource = await GetResourceDictionary(lang);
                _resources.GetOrAdd(strLang, currentLanguageResource);
            }

            return currentLanguageResource;
        }

        public static List<CultureInfo> GetSupportCultureInfo()
        {
            List<CultureInfo> cultures = new List<CultureInfo>();
            foreach (Culture culture in Cultures)
            {
                cultures.Add(new CultureInfo(culture.Code));
            }

            return cultures;
        }

        /// <summary>
        /// 用于多语言装换
        ///     ResourceSet 转换成 Dictionary
        /// </summary>
        /// <param name="Lang"></param>
        /// <returns></returns>
        private async static Task<ConcurrentDictionary<string, string>> GetResourceDictionary(string Lang)
        {
            ConcurrentDictionary<string, string> dict = new ConcurrentDictionary<string, string>();
            ResourceSet rs = await Task.Run(() => LanguageResources.GetResourceSet(CultureInfo.CreateSpecificCulture(Lang), true, false));
            if (rs != null)
            {
                IDictionaryEnumerator ide = rs.GetEnumerator();
                while (ide.MoveNext())
                {
                    dict.GetOrAdd(ide.Key.ToString(), ide.Value.ToString());
                }
            }
            return dict;
        }

        /// <summary>
        /// 如果以originalName为键的缓存不存在，则将implementedName缓存；如果存在，则使用implementedName更新
        /// </summary>
        /// <param name="originalName"></param>
        /// <param name="implementedName"></param>
        /// <returns></returns>
        private static string CacheCulture(string originalName, string implementedName)
        {
            _getImplementedCultureCache.AddOrUpdate(originalName, implementedName, (_, __) => implementedName);
            return implementedName;
        }
    }
}
