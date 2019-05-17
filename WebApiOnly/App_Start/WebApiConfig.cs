using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Routing;

namespace WebApiOnly
{
    /// <summary>
    /// 这个项目是新建的时候，选择空模板，然后勾选了Web API选项
    /// </summary>
    public static class WebApiConfig
    {
        //路由映射，从第一个往后的匹配路由
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由【启用特性路由】，
            //特性路由在Web Api2中开始支持，特性路由使用[Route()]特性，里面可以配置任何控制器和方法
            //为了使用特性路由，必须要写 config.MapHttpAttributeRoutes();
            config.MapHttpAttributeRoutes();

            //自定义路由[限制控制器只能是Hello,并且前缀是WebApi,不区分大小写]
            IHttpRoute route = config.Routes.CreateRoute("WebApi/{controller}",
                defaults: null, constraints: new { controller = "Hello" });
            config.Routes.Add("MyWebApi", route);

            //配置默认的控制器是Hello，
            //可以直接不输入控制器，浏览器直接输入http://localhost:53909/webapi，就定位到了Hello控制器的Get方法
            //输入 http://localhost:53909/webapi?name=asda  就定位到了Hello控制器的SayHi方法
            IHttpRoute route2 = config.Routes.CreateRoute("WebApi/{controller}", defaults: new { controller = "Hello" }, constraints: null);
            config.Routes.Add("MyWebApi2", route2);


            //配置JSON的格式化程序
            //{"id":4,"name":"曹雪芹","sex":"女"}
            JsonMediaTypeFormatter jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();


            //默认路由【搞一个api前缀是为了和ASP.NET MVC路由区分开】
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
