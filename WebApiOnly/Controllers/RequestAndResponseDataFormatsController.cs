using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiOnly.Controllers
{
    /// <summary>
    ///Web APi中的请求/相应的数据格式
    ///1. Media Type又叫MIME Type，指定了数据的格式，例如：text/html,text/xml,application/json,image/jpeg等等；
    ///2.在HTTP请求中，MIME type是通过请求报文头中的Accept和Content-Type特性指定的；
    ///3.Accept特性指定了客户端期望的响应的数据格式，Content-Type指定了请求体（request body）中数据格式，
    ///所以接收对象可以将其转化为合适的格式；
    ///4.例如如果客户端想要响应的数据的格式是json格式的，就可以在请求中加入【Accept: application/json】；
    ///5.同样的，如果客户端想要发送json格式的数据，那么就在请求体(request body)中加入:【Content-Type: application/json】；
    ///总结一句话，也就是，如果传入想要接收的结果是json的格式就使用Accept: application/json;
    ///如果想要接收的结果格式是XML格式的，就是用Accept: text/xml;
    ///如果想要发送的请求是json格式的,就使用Content-Type:application/json,然后在request body中写要发送到服务器的json的对象信息；
    ///如果想要发送的请求是xml格式的，就使用Content-Type:text/xml,然后在request body中写要发送到服务器的XML格式的对象信息；
    public class RequestAndResponseDataFormatsController : ApiController
    {

    }
}
