using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Common.Logger;

namespace WebApi
{
    public class Program
    {

        private IWebHost _webHost;

        public static void Main(string[] args)
        {
            //设定程序的输出字符集
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            new Program().CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 创建webhost并启动
        /// </summary>
        /// <param name="args"></param>
        public void Start(params string[] args)
        {
            _webHost = CreateWebHostBuilder(args).Build();
            _webHost.RunAsync(default(CancellationToken));
        }

        /// <summary>
        /// 停止创建webhost
        /// </summary>
        public void Stop()
        {
            _webHost.StopAsync(default(CancellationToken));
        }


        public IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .UseKestrel(SetHost)
                .UseIISIntegration()
                .UseContentRoot(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .UseStartup<Startup>();
        }

        /// <summary>
        /// 配置Kestrel服务器
        /// <para>
        /// 包括配置监听IP、端口、https、http等
        /// </para>
        /// </summary>
        /// <param name="options"></param>
        private void SetHost(Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions options)
        {
            IConfiguration configuration = (IConfiguration)options.ApplicationServices.GetService(typeof(IConfiguration));
            Host host = configuration.GetSection("Host").Get<Host>();
            ////使用json文件获取方法 获取配置文件
            //IConfigurationRoot config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: false)
            //    .Build();
            //Host host = config.GetSection("Host").Get<Host>(); //依据Host类反序列化appsettings.json中指定节点

            //遍历配置文件中 Host节点下的所有 EndPoint，进行Kestrel绑定
            foreach (KeyValuePair<string, Endpoint> epkv in host.Endpoints)
            {
                string epKey = epkv.Key;
                Endpoint endPoint = epkv.Value;
                //此EndPoint不启用，则不绑定Kestrel
                if (!endPoint.IsEnabled)
                {
                    continue;
                }

                //获取IP地址，并设置Kestrel的监听
                //Listens on all IPs using IPv6 [::], or IPv4 0.0.0.0 if IPv6 is not supported.
                IPAddress address = IPAddress.Parse(endPoint.Address);
                options.Listen(address, endPoint.Port, opts =>
                {
                    //证书不为空
                    if (endPoint.Certificate != null)
                    {
                        switch (endPoint.Certificate.Source)
                        {
                            case "File":
                                opts.UseHttps(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), endPoint.Certificate.Name), endPoint.Certificate.Password);
                                break;
                            default:
                                throw new NotImplementedException($"文件 {endPoint.Certificate.Source}还没有实现");
                        }
                    }
                });
                options.UseSystemd();
            }
        }
    }

    #region Kestrel配置使用的类

    /// <summary>
    /// 待反序列化节点
    /// </summary>
    public class Host
    {
        /// <summary>
        /// appsettings.json字典
        /// </summary>
        public Dictionary<string, Endpoint> Endpoints { get; set; }
    }

    /// <summary>
    /// 终结点
    /// </summary>
    public class Endpoint
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// ip地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 证书
        /// </summary>
        public Certificate Certificate { get; set; }
    }

    /// <summary>
    /// 证书类
    /// </summary>
    public class Certificate
    {
        /// <summary>
        /// 源
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 证书名称（都存放在根目录中）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 证书密钥
        /// </summary>
        public string Password { get; set; }
    }

    #endregion


}
