using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiOnly.Controllers
{
    /// <summary>
    /// Web API 过滤器【Web API Filters】
    /// 1.Web Api包含filters,它可以用来在方法执行之前或者执行之后，添加额外的逻辑，它提供了切面编程的特点，
    /// 例如：日志记录，异常处理，性能测量，验证和授权等；
    /// 2.Filter实际上就是特性，可以应用于Web API 控制器上，或者一个或多个方法上；
    /// 3.每一个Filter特性类，都必须要实现System.Web.Http.Filters命名空间下的IFilter接口；
    /// 4.System.Web.Http.Filters命名空间下，还包含其他的接口和类，可以用于创建Filter，用作特殊用途：
    /// 
    /// 
    /// </summary>
    public class FilterController : ApiController
    {
        //[Log]
        [Log2]
        [HttpGet]
        public string SayHello(string name)
        {
            return "你好哇: " + name;
        }

    }

    /// <summary>
    /// 方式一： 自定义一个LogAttribute特性类实现ActionFilterAttribute
    /// </summary>
    public class LogAttribute : ActionFilterAttribute
    {
        public LogAttribute()
        {

        }
        
        /// <summary>
        ///调用方法之前执行
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Trace.WriteLine(string.Format("Action Method {0} executing at {1}",actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()),"Web API Logs");
            //base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Trace.WriteLine(string.Format("Action Method {0} executed at {1}", actionExecutedContext.ActionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
            //base.OnActionExecuted(actionExecutedContext);
        }
    }

    public class Log2Attribute : Attribute, IActionFilter
    {
        public bool AllowMultiple
        {
            get { return true; }
        }
       // public bool AllowMultiple => throw new NotImplementedException();

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            Trace.WriteLine(string.Format("Action Method {0} executing at {1}", 
                actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");

            var result = continuation();
            result.Wait();
            Trace.WriteLine(string.Format("Action Method {0} executed at {1}", 
                actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
            return result;
            //throw new NotImplementedException();
        }
    }
}
