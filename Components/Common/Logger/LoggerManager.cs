using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logger.Log4Net;

namespace Common.Logger
{
    /// <summary>
    ///  日志管理器，用于管理具体使用哪个具象化的logger
    ///  1、使用时先用SetCurrent设置工厂对象
    ///  2、再使用ILogger获取具体的日志操作对象LoggerManager.Logger
    /// </summary>
    public class LoggerManager
    {
        /// <summary>
        /// 默认日志处理器
        /// </summary>
        public static ILogger DefaultLogger
        {
            get
            {
                return new Logger4Factory().CreateDefault();
            }
        }
    }
}
