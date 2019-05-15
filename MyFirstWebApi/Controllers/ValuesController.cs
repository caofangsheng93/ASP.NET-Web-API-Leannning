using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstWebApi.Controllers
{
    /// <summary>
    /// 1.Get处理Get请求【查询】，Post处理Post请求【插入】，Put处理Put请求【修改】，Delete处理Delete请求【删除】
    /// 2.如果想要自定义的名称，就需要给方法标识HTTP谓词【HttpGet,HttpPost,HttpPut,HttpDelete】
    /// </summary>
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }


        [HttpGet] //如果方法名称不是以Get或者Get作为前缀就必须要标识
        public IEnumerable<string> SayHello(string myName)
        {
            return new string[] { "Hello", "WepAPI" };
        }

        /// <summary>
        /// 方法名称是以Get作为前缀，就自动认为是HttpGet方法
        /// </summary>
        /// <param name="inputName"></param>
        /// <returns></returns>
        public string GetYourName(string inputName)
        {
            return "你的名字是:"+inputName;
        }

    }
}
