using DependencyInjectWithWebApi.Resolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DependencyInjectWithWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.DependencyResolver = new NinjectResolver();

            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller="Student", id = RouteParameter.Optional }
            );
        }
    }
}
