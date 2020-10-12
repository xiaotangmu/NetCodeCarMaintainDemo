using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Localization;
using WebApi.Utils.Globalization;

namespace WebApi.Utils.Globalization
{
    public class CustomCultureProvider : CookieRequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            string cultureName;
            //是否使用cookie记录语言
            if(httpContext.Request.Cookies.ContainsKey("_culture"))
            {
                cultureName = httpContext.Request.Cookies["_culture"];
            }
            //是否使用header记录语言
            else if(httpContext.Request.Headers.ContainsKey("Culture"))
            {
                cultureName = httpContext.Request.Headers["Culture"];
            }
            else
            {
                cultureName = CultureInfo.CurrentCulture.Name;
            }
            cultureName = CultureHelper.GetImplementedCulture(cultureName);
            //CultureInfo.CurrentCulture = new CultureInfo(cultureName);
            //CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            cultureName = CultureHelper.GetImplementedCulture(Thread.CurrentThread.CurrentCulture.Name); // This is safe
            // 把语言设置到响应头
            //httpContext.Response.Headers.Append("_culture",cultureName);
            //httpContext.Response.Cookies.Append("_culture", cultureName, new CookieOptions
            //{
            //    Expires = DateTime.Now.AddYears(1)
            //});
            Localizer.Init(Thread.CurrentThread.CurrentCulture);
            return base.DetermineProviderCultureResult(httpContext);
        }
    }
}
