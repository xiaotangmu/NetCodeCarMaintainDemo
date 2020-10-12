using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logger.Log4Net
{
    /// <summary>
    ///  使用log4net的config中的logger
    /// </summary>
    public enum LoggerType
    {
        FileRollingLogger,
        WebLogger
    }
}
