using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Common.Converter;
using Localization;
using WebApi.Models.Auth;
using WebApi.Models.Results;
using BLL.System;
using Microsoft.Extensions.Configuration;
using WebApi.Utils.Filters;
using ViewModel.Common;

namespace WebApi.MidWares
{
    /// <summary>
    /// Api权限管理中间件，不具备访问权限的api，会返回“无操作权限”
    /// 对拥有ImmuneApiAttribute属性的api，采取忽略
    /// </summary>
    public class ApiAuthorizeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private readonly IConfiguration _configuration;

        public ApiAuthorizeMiddleware(RequestDelegate next,
            IOptions<TokenProviderOptions> tokenOptions,
            IConfiguration configuration)
        {
            _next = next;
            _options = tokenOptions.Value;
            _configuration = configuration;
        }

        /// <summary>
        /// api权限认证处理，与角色权限相关联
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            //穿透权限防御层
            if (ApiAttributeFilter.IsImmuneApi(httpContext))
            {
                await _next(httpContext);
                return;
            }
            //验证Api有效性
            //if (!await ValidateApi(httpContext))
            //{
            //    return;
            //}
            await _next(httpContext);
        }

        private async Task<bool> ValidateApi(HttpContext httpContext)
        {
            string api = httpContext.Request.Path.Value.Replace(Startup.ApiPrefix, "");
            if (api.StartsWith("//"))
            {
                api = api.Remove(0, 1);
            }
            if (!OpenAuthorityValid())
            {
                return true;
            }
            //api权限过滤，开发方便，暂先注释 xavier
            //当前访问的用户信息
           //CurrentUserInfo currentUser = TokenDecoder.GetCurrentUserInfo(httpContext, _options);
            if (!await new AuthorizationManagement().IsAuthorize(api, Startup.CurrentUser))
            {
                await SetHttpResponse(httpContext, MsgCode.Session_NotPermission, await Localizer.GetValueAsync("NotPermission"));
                return false;
            }
            return true;
        }

        private bool OpenAuthorityValid()
        {
            string isOpen = _configuration.GetSection("AuthoritySwitch").Value;
            if (isOpen.ToLower().Trim().Equals("1"))//1爲開啓API驗證
            {
                return true;
            }
            return false;
        }

        private async Task SetHttpResponse(HttpContext httpContext, MsgCode code, string message)
        {
            ResultData result = new ResultData();
            result.code = code;
            result.message = message;
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 200;
            await httpContext.Response.WriteAsync(JsonConverter.Serialize(result));
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApiAuthorizeMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiAuthorizeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiAuthorizeMiddleware>();
        }
    }
}
