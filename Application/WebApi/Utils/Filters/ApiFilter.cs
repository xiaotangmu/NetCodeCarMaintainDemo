using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApi.SysFrame.CustomAttribute;

namespace WebApi.Utils.Filters
{
    public class ApiAttributeFilter
    {
        public static bool IsAuthorize(HttpContext context)
        {
            string apiPath = DecoderApi(context);
            MethodInfo method = GetMethodByApi(apiPath);
            if (method == null)
            {
                return false;
            }
            if (IsParentAuthorize(apiPath))
            {
                if (IsAllowAnonymous(method))
                {
                    return false;
                }
            }
            else
            {
                if (!IsMethodAuthorize(method))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsImmuneApi(HttpContext context)
        {
            string apiPath = DecoderApi(context);
            MethodInfo method = GetMethodByApi(apiPath);
            if (method == null)
            {
                return false;
            }
            Attribute attribute = method.GetCustomAttribute(typeof(SysFrame.CustomAttribute.ImmuneApiAttribute));
            if (attribute == null)
            {
                return false;
            }
            return true;
        }

        private static string DecoderApi(HttpContext context)
        {
            string api = context.Request.Path.Value.Replace(Startup.ApiPrefix, "");
            if (api.StartsWith("//"))
            {
                api = api.Remove(0, 1);
            }
            return api;
        }

        private static bool IsParentAuthorize(string apiPath)
        {
            string controllerName = apiPath.Substring(apiPath.IndexOf("/") + 1, apiPath.LastIndexOf("/") - 1);
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            if (currentAssembly == null)
            {
                return false;
            }
            foreach (var type in currentAssembly.GetExportedTypes())
            {
                if (type == null || type.BaseType == null || !type.BaseType.Equals(typeof(Controllers.BaseController)))
                {
                    continue;
                }
                if (!type.Name.Equals(controllerName + "Controller"))
                {
                    continue;
                }
                Attribute attribute = type.GetCustomAttribute(typeof(AuthorizeAttribute));
                if (attribute != null)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsMethodAuthorize(MethodInfo method)
        {
            Attribute attribute = method.GetCustomAttribute(typeof(AuthorizeAttribute));
            if (attribute == null)
            {
                return false;
            }
            return true;
        }

        private static bool IsAllowAnonymous(MethodInfo method)
        {
            Attribute attribute = method.GetCustomAttribute(typeof(AllowAnonymousAttribute));
            if (attribute == null)
            {
                return false;
            }
            return true;
        }

        private static MethodInfo GetMethodByApi(string apiPath)
        {
            string methodName = apiPath.Substring(apiPath.LastIndexOf("/") + 1, apiPath.Length - apiPath.LastIndexOf("/") - 1);
            string controllerName = apiPath.Substring(apiPath.IndexOf("/") + 1, apiPath.LastIndexOf("/") - 1);
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            if (currentAssembly == null)
            {
                return null;
            }
            foreach (var type in currentAssembly.GetExportedTypes())
            {
                if (type == null || type.BaseType == null || !type.BaseType.Equals(typeof(Controllers.BaseController)))
                {
                    continue;
                }
                if (!type.Name.Equals(controllerName + "Controller"))
                {
                    continue;
                }
                MethodInfo method = type.GetMethod(methodName);
                if (method == null)
                {
                    continue;
                }
                return method;
            }
            return null;
        }
    }
}
