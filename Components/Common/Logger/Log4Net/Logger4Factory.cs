using log4net.Repository;
using System;
using System.Reflection;

namespace Common.Logger.Log4Net
{
    public class Logger4Factory : ILoggerFactory
    {
        //此路径为根目录路径，不是程序运行起点路径（例如web中的bin目录）
        private static string strLoggerConfigPath = AppDomain.CurrentDomain.BaseDirectory + "/Logger/Log4Net/log4net.config";
        private static ILoggerRepository _repository;

        public Logger4Factory()
        {
            _repository = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
        }

        public ILogger Create(string configPath)
        {
            SetConfig(configPath);
            return new Logger4Helper(_repository.Name);
        }

        public ILogger CreateDefault()
        {
            SetConfig();
            return new Logger4Helper(_repository.Name);
        }

        /// <summary>
        /// 设置配置文件路径
        /// </summary>
        /// <param name="configPath"></param>
        private void SetConfig(string configPath = "")
        {
            if (string.IsNullOrWhiteSpace(configPath))
            {
                using (var fs = System.IO.File.OpenRead(strLoggerConfigPath))
                {
                    log4net.Config.XmlConfigurator.Configure(_repository, fs);
                }
            }
            else
            {
                using (var fs = System.IO.File.OpenRead(configPath))
                {
                    log4net.Config.XmlConfigurator.Configure(_repository, fs);
                }
            }
        }
    }
}
