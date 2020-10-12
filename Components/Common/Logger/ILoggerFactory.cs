using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logger
{
    public interface ILoggerFactory
    {
        /// <summary>
        ///  创建logger处理器
        /// </summary>
        /// <returns> The ILog created </returns>
        ILogger Create(string configPath);

        /// <summary>
        /// 创建默认Logger
        /// </summary>
        /// <returns></returns>
        ILogger CreateDefault();
    }
}
