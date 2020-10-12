using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.SysFrame.Route
{
    /// <summary>
    /// Mvc功能扩展
    /// </summary>
    public static class MvcOptionsExtensions
    {
        public static void UseCentraRoutePrefix(this MvcOptions opts,IRouteTemplateProvider routeProvider)
        {
            //添加自定义 实现的 全局路由前缀
            opts.Conventions.Insert(0, new RouteConvention(routeProvider));
        }
    }
}
