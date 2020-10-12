using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.SysFrame.Route
{
    /// <summary>
    /// 全局路由前缀配置
    /// <para>
    /// 用于自定义前缀，方便后期更改路由版本等
    /// </para>
    /// </summary>
    public class RouteConvention : IApplicationModelConvention
    {
        /// <summary>
        /// 路由前缀变量
        /// </summary>
        private readonly AttributeRouteModel _centralPrefix;

        /// <summary>
        /// 构造时传入指定的路由前缀
        /// </summary>
        /// <param name="routeTemplateProvider"></param>
        public RouteConvention( IRouteTemplateProvider routeTemplateProvider )
        {
            _centralPrefix = new AttributeRouteModel(routeTemplateProvider);
        }

        #region  IApplicationModelConvention
        public void Apply(ApplicationModel application)
        {
            //遍历所有Controller，添加前缀（一部分是有路由配置，一部分木有路由配置）
            foreach(var controller in application.Controllers)
            {
                //找已经标记了RouteAttribute的Controller
                List<SelectorModel> matched = controller.Selectors.Where(x =>
                    x.AttributeRouteModel != null).ToList();
                if(matched.Any())
                {
                    foreach(var selectorModel in matched)
                    {
                        //在当前路由上再添加一个路由前缀
                        selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_centralPrefix, selectorModel.AttributeRouteModel);
                    }
                }
                //2、 没有标记 RouteAttribute 的 Controller
                var unmatchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();
                if (unmatchedSelectors.Any())
                {
                    foreach (var selectorModel in unmatchedSelectors)
                    {
                        // 添加一个 路由前缀
                        selectorModel.AttributeRouteModel = _centralPrefix;
                    }
                }
            }
        }
        #endregion
    }
}
