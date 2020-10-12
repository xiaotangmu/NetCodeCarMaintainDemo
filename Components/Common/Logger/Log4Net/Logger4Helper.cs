using log4net;
using System;
using System.Linq;

//[assembly: Config.XmlConfigurator(ConfigFile = @"config", Watch = true)]
namespace Common.Logger.Log4Net
{
    internal class Logger4Helper : ILogger
    {
        private string _repository = string.Empty;

        public Logger4Helper(string repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 记录Debug信息
        /// </summary>
        /// <param name="message"> 需记录的信息 </param>
        /// <param name="args">具体的Logger名称 </param>
        public void Debug(string message, LoggerType type = LoggerType.FileRollingLogger)
        {
            ILog log = LogManager.GetLogger(_repository, type.ToString());
            log.Debug(message);
        }

        /// <summary>
        /// 记录Debug信息
        /// </summary>
        /// <param name="message"> 需记录的信息 </param>
        /// <param name="exception"> 异常类型 </param>
        /// <param name="args">具体的Logger名称</param>
        public void Debug(string message, Exception exception, LoggerType type = LoggerType.FileRollingLogger)
        {
            ILog log = LogManager.GetLogger(_repository, type.ToString());
            log.Debug(message, exception);
        }

        /// <summary>
        /// 记录Debug信息
        /// </summary>
        /// <param name="item"> 对象 </param>
        public void Debug(object item, LoggerType type = LoggerType.FileRollingLogger)
        {
            ILog log = LogManager.GetLogger(_repository, type.ToString());
            log.Debug(item);
        }

        /// <summary>
        /// 记录Fatal信息
        /// </summary>
        /// <param name="message"> 需记录的信息 </param>
        /// <param name="args"> 具体的Logger名称 </param>
        public void Fatal(string message, LoggerType type = LoggerType.FileRollingLogger)
        {
            ILog log = LogManager.GetLogger(_repository, type.ToString());
            log.Fatal(message);
        }

        /// <summary>
        /// 记录Fatal信息
        /// </summary>
        /// <param name="message"> 需记录的信息 </param>
        /// <param name="exception"> 异常类型 </param>
        public void Fatal(string message, Exception exception, LoggerType type = LoggerType.FileRollingLogger)
        {
            ILog log = LogManager.GetLogger(_repository, type.ToString());
            log.Fatal(message, exception);
        }

        /// <summary>
        /// 记录Info信息
        /// </summary>
        /// <param name="message"> 需记录的信息 </param>
        /// <param name="args"> 具体的Logger名称 </param>
        public void Info(string message, LoggerType type = LoggerType.FileRollingLogger)
        {
            ILog log = LogManager.GetLogger(_repository, type.ToString());
            log.Info(message);
        }

        /// <summary>
        ///  记录Warning信息
        /// </summary>
        /// <param name="message"> 需记录的信息</param>
        /// <param name="args">具体的Logger名称</param>
        public void Warning(string message, LoggerType type = LoggerType.FileRollingLogger)
        {
            ILog log = LogManager.GetLogger(_repository, type.ToString());
            log.Warn(message);
        }

        /// <summary>
        /// 记录Error信息
        /// </summary>
        /// <param name="message"> 需记录的信息 </param>
        /// <param name="args">具体的Logger名称 </param>
        public void Error(string message, LoggerType type = LoggerType.FileRollingLogger)
        {
            ILog log = LogManager.GetLogger(_repository, type.ToString());
            log.Error(message);
        }

        /// <summary>
        /// 记录Error信息
        /// </summary>
        /// <param name="message">需记录的信息 </param>
        /// <param name="exception"> 异常类型 </param>
        /// <param name="args"> 具体的Logger名称 </param>
        public void Error(string message, Exception exception, LoggerType type = LoggerType.FileRollingLogger)
        {
            ILog log = LogManager.GetLogger(_repository, type.ToString());
            log.Error(message, exception);
        }
    }
}
