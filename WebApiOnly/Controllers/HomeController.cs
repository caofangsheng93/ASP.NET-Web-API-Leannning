using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiOnly.Controllers
{

    /// <summary>
    /// Web API 控制器的特点：
    /// 1.必须要继承自System.Web.Http命名空间下的ApiController类；
    /// 2.Web api控制器可以在项目的任何目录下面，但是推荐是在Controller文件夹下【根据默认约定】；
    /// 3.控制器中的方法，必须要和Http 谓词名称一样【Get,Post,Put,Delete（不区分大小写）等】，
    /// 或者以Http 谓词作为前缀【Get,Post,Put,Delete（不区分大小写）等作为前缀】，
    /// 不然的话，你就需要给方法标识Http特性【HttpGet、HttpPost、httpPut、HttpDelete（不区分大小写）等】
    /// 4.控制器中的方法返回值类型可以是任何原始类型或者任何复杂类型。
    /// </summary>
    public class HomeController : ApiController
    {
        //标识之后，在浏览器输入：http://localhost:53909/api/Home/GetDatas?name=sss  就可以访问了
        [Route("api/Home/GetDatas")]
        public string Get(string name)
        {
            return "你好哇："+name+"欢迎您来到ASP Web Api的世界";
        }
    }
}
