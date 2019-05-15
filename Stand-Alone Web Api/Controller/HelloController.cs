using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Stand_Alone_Web_Api.Controller
{
    public class HelloController : ApiController
    {
        public string Get()
        {
            return "Hello ASP.NET Web Api World";
        }
    }
}
