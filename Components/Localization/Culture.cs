using System;

namespace Localization
{
    public class Culture
    {
        /// <summary>
        /// EX：zh-CN/zh-MO
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 对应的文字表达，Ex：简体中文/繁体中文
        /// </summary>
        public string Name { get; set; }
    }
}
