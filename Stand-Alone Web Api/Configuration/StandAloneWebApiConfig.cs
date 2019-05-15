using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

/// <summary>
/// 1.创建一个独立的WEP API应用程序，是选择空模板，然后直接点击确定；
/// 2.在新建的项目中，通过Nuget引用WebApi
/// 3.创建两个文件夹Configuration和Controller
/// 4.在Configuration文件夹中写一个路由配置类
/// 5.在Controller文件夹中，新建一个空白的WebApi控制器
/// </summary>
namespace Stand_Alone_Web_Api.Configuration
{

    /// <summary>
    /// Web Api 是通过 System.Web.Http命名空间下的 HttpConfiguration类来配置的
    /// </summary>
     public static class StandAloneWebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Web Api路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name:"DefaultApi",
                routeTemplate:"api/{controller}/{id}",
                defaults: new { id=RouteParameter.Optional}
                );
        }
    }
}