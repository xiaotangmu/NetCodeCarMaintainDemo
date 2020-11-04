using ApiDocUi.Filters;
using Autofac;
using BLL.Catalog;
using BLL.Client;
using BLL.Maintain;
using BLL.Sku;
using BLL.Spu;
using BLL.System;
using BLL.User;
using DataModel.System;
using Localization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Supervisor.Catalog;
using Supervisor.Client;
using Supervisor.Maintain;
using Supervisor.Sku;
using Supervisor.Spu;
using Supervisor.System;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApi.MidWares;
using WebApi.Models.Auth;
using WebApi.SysFrame.Route;
using WebApi.Utils.Globalization;

namespace WebApi
{
    public class Startup
    {
        /// <summary>
        /// 服务集合
        /// </summary>
        private IServiceCollection _services;

        /// <summary>
        /// 临时文件目录
        /// </summary>
        public static string TemporaryFileDirectory { get; private set; }

        /// <summary>
        /// 当前服务根目录
        /// </summary>
        public static string CurrentContentPath { get; private set; }

        public static CurrentUserInfo CurrentUser { get; set; }

        /// <summary>
        /// 应用程序配置
        /// </summary>
        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        public static string ApiPrefix { get; private set; } = "api/v0.1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 配置服务，在运行时被调用
        /// <para>
        /// 在此方法内添加或配置服务
        /// </para>
        /// </summary>
        /// <param name="services">服务集合</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //添加配置可以注入controller
            services.Configure<TokenProviderOptions>(Configuration.GetSection("Jwt"));
            TokenProviderOptions tokenOptions = new TokenProviderOptions();
            Configuration.Bind("Jwt", tokenOptions);

            JWTTokenValid(services);

            #region 跨域策略
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                      .AllowAnyOrigin() //.WithOrigins(new string[] {"",""})
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials()
                .Build());
            });
            #endregion

            #region Swagger Api文档
            //注入实现ISwaggerProvider使用默认设置
            services.AddSwaggerGen(options =>
            {
                //"v1"为SwaggerOptions中RouteTemplate方法的{documentName}
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API文档",
                    Description = "API接口描述文档",
                    //TermsOfService = "None",
                    //Contact = new Contact { Name = "Arvin Lv", Email = "lxl@jadedragontech.com", Url = "http://www.jadedragontech.com" },
                    //License = new License { Name = "Apache2.0", Url = "https://www.apache.org/licenses/LICENSE-2.0.html" }
                });

                //获取应用程序根路径 （跨平台） 
                var basePath = Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationBasePath;
                //设置XML注释文件的完整路径
                var xmlPath = Path.Combine(basePath, "WebApi.xml");
                options.IncludeXmlComments(xmlPath);

                //修改doc，增加自定义节点（分组内容，需使用 SwaggerControllerGroup特性）
                options.DocumentFilter<GroupDocFilter>(xmlPath);

            });
            #endregion

            #region MVC服务
            services.AddMvc(options =>
            {
                options.UseCentraRoutePrefix(new RouteAttribute(ApiPrefix));
            })
                .AddJsonOptions(options =>
                {
                    //解决返回json小写问题
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create("Language", Assembly.GetExecutingAssembly().FullName);
                });
            #endregion

            #region 语言全球化本地化配置，默认语言设置为zh-CN

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(CultureHelper.GetDefaultCulture());
                IList<CultureInfo> supportCulture = new List<CultureInfo>();
                foreach (Culture culture in CultureHelper.Cultures)
                {
                    supportCulture.Add(new CultureInfo(culture.Code));
                }
                options.SupportedCultures = CultureHelper.GetSupportCultureInfo();
                options.SupportedUICultures = options.SupportedCultures;
                //自定义的语言文化供应商类，并作为首位匹配
                options.RequestCultureProviders.Insert(0, new CustomCultureProvider());
            });
            services.AddMemoryCache();

            #endregion

            #region 用于https请求
            //services.AddAntiforgery(options=> {
            //    options.Cookie.Name = "_af";
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            //    options.HeaderName = "X-XSRF-TOKEN";
            //});
            #endregion

            services.AddSingleton(Configuration);
            services.AddScoped<IClientSupervisor, ClientSupervisor>();
            services.AddScoped<IAppointmentSupervisor, AppointmentSupervisor>();
            services.AddScoped<IMaintainSupervisor, MaintainSupervisor>();
            services.AddScoped<ISkuSupervisor, SkuSupervisor>();
            services.AddScoped<IEntrySupervisor, EntrySupervisor>();
            services.AddScoped<IOutSupervisor, OutSupervisor>();
            services.AddScoped<ICheckSupervisor, CheckSupervisor>();
            services.AddScoped<IAttrSupervisor, AttrSupervisor>();
            services.AddScoped<ICatalog1Supervisor, Catalog1Supervisor>();
            services.AddScoped<ICatalog2Supervisor, Catalog2Supervisor>();
            services.AddScoped<ISpuSupervisor, SpuSupervisor>();
            services.AddScoped<Supervisor.User.IUserSupervisor, UserSupervisor>();

            services.AddScoped<IDictSupervisor, DictManagement>();
            services.AddScoped<IPermissionSupervisor, PermissionManagement>();
            services.AddScoped<IRoleSupervisor, RoleManagement>();
            //services.AddScoped<IUserSupervisor, UserManagement>();
            services.AddScoped<IEmailTemplateSupervisor, EmailTemplateSupervisor>();
            services.AddScoped<ISystemConfigurationSupervisor, SystemConfigurationSupervisor>();

            services.AddHttpClient();
            _services = services;
        }

        private void JWTTokenValid(IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
                            .AddIdentityServerAuthentication(options =>
                            {
                                options.Authority = Configuration.GetSection("ADFS:ADFSDiscoveryDoc").Value;
                                options.RequireHttpsMetadata = false;
                                options.JwtBearerEvents = new JwtBearerEvents
                                {
                                    OnTokenValidated = context =>
                                    {
                                        GenerateCurrentUser(context.Principal);
                                        return Task.CompletedTask;
                                    }
                                };
                            });
        }

        private void GenerateCurrentUser(System.Security.Claims.ClaimsPrincipal principal)
        {
            CurrentUser = new CurrentUserInfo();
            CurrentUser.Account = principal.Claims.FirstOrDefault(claim => claim.Type == "unique_name").Value;
            if (!string.IsNullOrEmpty(CurrentUser.Account))
            {
                CurrentUser.UserType = UserType.USER;
            }
        }

        /// <summary>
        /// 配置HTTP请求管道
        /// <para>
        /// 在运行时被调用
        /// </para>
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //开发环境
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                #region 跨域配置--开发环境
                app.UseCors(builder =>
                {
                    builder.AllowAnyHeader();   //允许任何Header部
                    builder.AllowAnyMethod();  //允许任何方法
                    builder.AllowAnyOrigin();  // 开发环境允许任何来源地址
                });
                #endregion
            }
            else
            {
                #region 统一异常处理
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {

                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
                #endregion

                #region 跨域配置--生产环境
                app.UseCors(builder =>
                {
                    builder.AllowAnyHeader();   //允许任何Header部
                    builder.AllowAnyMethod();  //允许任何方法
                    builder.WithOrigins(GetCorsHost());  //指定请求的来源地址
                });
                #endregion

                //app.UseHsts();
            }

            #region Api文档管道
            //启用静态访问
            app.UseStaticFiles();
            //使用中间件服务生成Swagger作为JSON端点
            app.UseSwagger();
            //使用中间件服务Swagger-ui assets（HTML、javascript、CSS等）
            //app.UseSwaggerUI();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RMS API V1");
                c.DocumentTitle = "API文档";
                c.RoutePrefix = "api/doc";
            });
            #endregion

            #region 认证
            app.UseTokenIdentityMiddleware();
            app.UseAuthentication();
            #endregion
            //Api权限验证
            app.UseApiAuthorizeMiddleware();
            //string logFilePath = Configuration["Logging:LogFilePath"];
            //loggerFactory.AddLog4Net(new[] {
            //    log4netConfiguration.CreateRollingFileAppender(logFilePath)
            //});
            app.UseRequestLocalization();

            CurrentContentPath = env.ContentRootPath;
            TemporaryFileDirectory = Path.Combine(CurrentContentPath, Configuration.GetSection("ExportTemporaryDirectory").Value);

            #region 日志

            #endregion
            app.UseMvc();   //api项目不使用Area路由
        }

        private string[] GetCorsHost()
        {
            List<string> hosts = new List<string>();
            IConfigurationSection sections = Configuration.GetSection("CorsHost").GetSection("Endpoints");
            foreach (var section in sections.GetChildren())
            {
                string httpUrl = string.Empty;
                if (!string.IsNullOrEmpty(section["Http:Port"]))
                {
                    httpUrl = string.Format("http://{0}:{1}", section["Http:Address"], section["Http:Port"]);
                }
                else
                {
                    httpUrl = string.Format("http://{0}", section["Http:Address"]);
                }
                string httpsUrl = string.Empty;
                if (!string.IsNullOrEmpty(section["Https:Port"]))
                {
                    httpsUrl = string.Format("https://{0}:{1}", section["Https:Address"], section["Https:Port"]);
                }
                else
                {
                    httpsUrl = string.Format("https://{0}", section["Https:Address"]);
                }
                hosts.Add(httpUrl);
                hosts.Add(httpsUrl);
            }
            return hosts.ToArray();
        }
    }
}
