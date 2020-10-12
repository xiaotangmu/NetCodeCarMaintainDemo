using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.MidWares
{
    /// <summary>
    /// 请求IP记录器
    /// </summary>
    public class RequestIPMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestIPMiddleware(RequestDelegate next,ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestIPMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("User IP:" + context.Connection.LocalIpAddress.ToString());
            await _next.Invoke(context);
        }

    }

    public static class RequestIPExtensions
    {
        public static IApplicationBuilder UseRequestIP(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("app");
            }
            return builder.UseMiddleware<RequestIPMiddleware>();
        }
    }

}
