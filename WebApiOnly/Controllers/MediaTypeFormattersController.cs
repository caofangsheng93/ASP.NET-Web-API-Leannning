using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WebApiOnly.Controllers
{
    /// <summary>
    /// Web API中的媒体类型的格式化程序【ASP.NET Web API: Media-Type Formatters】
    /// 1.前面的章节中，你已经看到了Web API基于Accept和Content-Type特性来处理JSON和XML格式的数据，
    /// 但是它怎么处理这些不同的格式的数据呢？答案就是使用Media-Type Formatters；
    /// 2.媒体类型的格式程序，就是一些类，主要用来序列号请求/响应的数据，所以客户端能够获取到，
    /// 所期待格式的请求数据和发送相应格式的数据给服务器。
    /// 3.Web API包含下面的内置的媒体类型格式化程序：
    /// 3.1. JsonMediaTypeFormatter、
    /// 3.2. XmlMediaTypeFormatter、
    /// 3.3. FormUrlEncodedMediaTypeFormatter、
    /// 3.4. JQueryMvcFormUrlEncodedFormatter
    /// 4.Web Api还有一个内置的BsonMediaTypeFormatter用来处理BSON格式的数据，但是默认是禁用的
    /// 5.JsonMediaTypeFormatter用来处理JSON格式的数据，它将http请求中的JSON数据转化为CLR对象，
    /// 同样将CLR对象转换为JSON格式的数据，嵌入到Http响应中，这样用户就可看到了JSON格式的数据了，
    /// 此外JsonMediaTypeFormatter，在内部是使用第三方的开源类库JSON.NET来处理序列化；
    /// 6.配置JSON的序列化：在WebApiConfig类中进行配置，JsonMediaTypeFormatter类包含很多属性和方法，
    /// 你可以用来自定义配置JSON的序列化，例如：Web APi默认是以PascalCase命名法来输出JSON属性，
    /// 可以使用CamelCasePropertyNamesContractResolver 来使用camelCase命名法。
    /// 
    /// 
    /// </summary>
    public class MediaTypeFormattersController : ApiController
    {
        public IEnumerable<string> GetAllMediaTypeFormatters()
        {
            IList<string> formatters = new List<string>();
            foreach (MediaTypeFormatter item in GlobalConfiguration.Configuration.Formatters)
            {
                formatters.Add(item.ToString());
            }
            return formatters;
        }
    }
}
