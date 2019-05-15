using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiOnly.Models;

namespace WebApiOnly.Controllers
{
    /// <summary>
    /// 参数绑定：【给方法的参数绑定数值：将请求的数据绑定到Action方法的参数上】
    /// 1.控制器的方法，可以有一个或者多个不同类型的参数；
    /// 2.控制器方法的参数类型可以是原始类型或者复杂类型；
    /// 3.Web API要么通过URL中的query string给参数绑定值，要么通过基于参数的类型，通过请求方法体【request body】给参数赋值；
    /// 4.默认情况下，如果参数的类型是可以从string类型转化而来的原始类型（例如：int、bool、double、GUID、Datetime、Decimal等），
    /// 就直接是通过query string给参数赋值；
    /// 5.默认情况下，如果参数的类型是复杂类型，web api就通过请求体（request body）给参数赋值
    /// 6.通过QueryString给方法的参数赋值，必须要确保参数的名字一样，大小写无所谓，
    /// 如果有多个参数，通过QueryString赋值的时候，URL中参数的顺序无所谓
    /// 7.Post方法包含原始类型参数和复杂类型参数的时候（混合参数），默认情况下，Web Api从Query string 中获取原始参数的值，
    /// 然后从Request Body中获取复杂类型的值
    /// 8.请注意，Post类型的方法，不能包含多个复杂类型的参数，因为只能从请求体中读取一个参数，Put和Patch类型的方法也是。
    /// 9.你已经知道，Web API默认从Query String中获取原始类型参数的值赋值给方法参数，
    /// 默认从Request Body中获取参数的值给复杂类型的参数，但是如果我们想要改变这样的默认规则呢？怎么处理？
    /// 答案就是使用【FromUri】和【FromBody】,【FromUri强制Web API从query string中获取值给复杂的参数赋值】；
    /// 【FromBody强制Web API从Request Body中获取值，给原始类型的参数绑定值】
    /// 10.请注意：FromBody只能应用于方法的一个原始类型的参数上，不能用于有多个原始类型的参数的方法上。
    /// </summary>
    public class HelloController : ApiController
    {
        [HttpGet]
        public string SayHi(string name)
        {
            return "你好哦:" + name;
        }

        public string Get()
        {
            return "我是Hello控制器中的Get方法";
        }

        public string GetStudentInfo(string name, int age)
        {
            return string.Format("My name is {0} and I'm {1} years old", name, age);
        }

        public string Post([FromBody]  string name)
        {
            return string.Format("Inserted One Student Data of Name={0}", name);
        }

        //public string PostStudent([FromUri] Student model)
        //{
        //    return string.Format("编号:{0},姓名:{1},性别:{2}",model.ID,model.Name,model.Sex);
        //}

        //public string PostNewStudent(string strHello, Student model)
        //{
        //    return string.Format("strHello={0}, My Name is {1} ,I'm {2},我的编号是：{3}",strHello,model.Name,model.Sex,model.ID);
        //}

        
    }
}
