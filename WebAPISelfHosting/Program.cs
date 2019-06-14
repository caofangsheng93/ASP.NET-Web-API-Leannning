using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;

namespace WebAPISelfHosting
{
    class Program
    {
        /// <summary>
        /// WEB API 可以有两种方式发布：
        /// 1.托管在IIS中【IIS Hosting】
        /// 2.自托管【Self Hosting】
        /// 自托管有两步：
        /// 2.1. 使用HttpConfiguration配置Web Api
        /// 2.2. 创建HttpServer然后开始监听http请求
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:1234");
            var server = new HttpSelfHostServer(config,new MyWebAPIMessageHandler());
            var task = server.OpenAsync();
            task.Wait();
            Console.WriteLine("Web API 服务已经启动了：http://localhost:1234");
            Console.ReadKey();
        }
    }
   public class MyWebAPIMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var task = new Task<HttpResponseMessage>(() => 
            {
                var resMsg = new HttpResponseMessage();
                resMsg.Content = new StringContent("Hello World!");
                return resMsg;
            });
            task.Wait();
            return task;
        }
    }

}
