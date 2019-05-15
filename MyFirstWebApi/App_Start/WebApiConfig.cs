using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MyFirstWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 允许特性 路由
            config.MapHttpAttributeRoutes();

            //默认的路由【基于约定的路由】
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
