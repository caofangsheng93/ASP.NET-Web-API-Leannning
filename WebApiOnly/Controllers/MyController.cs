using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiOnly.Models;

namespace WebApiOnly.Controllers
{
    public class MyController : ApiController
    {
        private List<Student> StudentListModel = new List<Student>();

        public MyController()
        {
            StudentListModel.Add(new Student() { ID = 1, Name = "曹操", Sex = "男" });
            StudentListModel.Add(new Student() { ID = 2, Name = "孙权", Sex = "男" });
            StudentListModel.Add(new Student() { ID = 3, Name = "刘备", Sex = "男" });
        }
        /*
         Web API有下面的返回值类型
         1.Void
         2.Primitive type or Complex type
         3.HttpResponseMessage  :优点是，可以根据需要设置状态码、内容、或者错误消息（如果有错误的话）
         4.IHttpActionResult   从Web Api 2中开始推出来，你可以使用ApiController类中的各种返回实现了 
         IHttpActionResult的对象，也可以自己编写自定义类实现IHttpActionResult接口

         */

        //  Void：并不是所有的Web API方法都要返回一些数据，同样可以使用Void类型,Void方法返回的是204---> No Content
        [HttpGet]
        public void SayHello()
        {
            Console.WriteLine("Hi，我是Web API的void类型的方法。");
        }

        //原始类型 Primitive type--->如果成功调用，返回的是字符串 状态码是200 OK
        public string GetName(string name)
        {
            return "你好哇" + name;
        }

        //复杂类型--> 如果成功调用，返回的是字符串 状态码是200 OK
        //public List<Student> GetStudents(int id)
        //{
        //    List<Student> lstModel = new List<Student>();
        //    lstModel.Add(new Student() { ID = 1, Name = "曹操", Sex = "男" });
        //    lstModel.Add(new Student() { ID = 2, Name = "孙权", Sex = "男" });
        //    lstModel.Add(new Student() { ID = 3, Name = "刘备", Sex = "男" });
        //    return lstModel;
        //}

        //通过HttprequestMessage的扩展方法CreateResponse,返回HttpResponseMessage对象
        public HttpResponseMessage GetStudent(int id)
        {
            Student stuModel = GetStudentById(id);
            if (stuModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, stuModel);
        }


        public IHttpActionResult PostStudent()
        {
            Student model = new Student();
            model.ID = 4;
            model.Name = "曹雪芹";
            model.Sex = "女";

            StudentListModel.Add(model);
            return Ok(model);
        }

        /// <summary>
        /// 自定义的类实现IHttpActionResult接口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult DeleteStudent(int id)
        {
            Student stuDelete = StudentListModel.Find(s => s.ID == id);
            if (stuDelete == null)
            {
                return new CustomClass(id.ToString(), Request);
            }
            else
            {
                StudentListModel.Remove(stuDelete);
                return new CustomClass("删除成功:" + id.ToString(), Request);
            }
           
        }

        /// <summary>
        /// 测试数据
        /// </summary>
        /// <returns></returns>
        private Student GetStudentById(int id)
        {
            Student stu = StudentListModel.Where(s => s.ID == id).FirstOrDefault();
            return stu;
        }
    }

    /// <summary>
    /// 自定义类实现IHttpActionResult接口的ExecuteAsync方法
    /// </summary>
    public class CustomClass : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;

        public CustomClass(string value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content=new StringContent(_value),
                RequestMessage=_request
            };
            return Task.FromResult(response);
            //throw new NotImplementedException();
        }
    }
}
