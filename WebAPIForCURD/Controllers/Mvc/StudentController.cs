using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPIForCURD.Models;

namespace WebAPIForCURD.Controllers.Mvc
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<StudentViewModel> students = null;
            /*
             * 使用HttpClient测试WebApi的方法
             1.发送请求
             2.读取数据
             */
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57991/api/");
                //Http Get请求
                var responseTask = client.GetAsync("Student");  //以异步的方式将Get请求发送给指定的URI
                responseTask.Wait(); //等待请求执行完
                var result = responseTask.Result;
                //如果请求成功
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<StudentViewModel>>();
                    readTask.Wait();//等待读取完毕
                    students = readTask.Result;
                }
                //web api 发送过来的错误
                else
                {
                    //记录返回的状态
                    students = Enumerable.Empty<StudentViewModel>();
                    ModelState.AddModelError(string.Empty, "系统错误请联系管理员！");
                }
            }
            return View(students);
        }

        public ActionResult Create()
        {
            //List<SelectListItem> list = new List<SelectListItem>();
            //using (var db = new EFDemoDBEntities())
            //{
            //    var grades = db.Grades.Select(s => new { s.GradeID, s.GradeName }).ToList();
            //    if (grades != null)
            //    {
            //        grades.ForEach(s => list.Add(new SelectListItem() { Value = s.GradeID.ToString(), Text = s.GradeName }));
            //    }
            //}
            //ViewBag.GradeList = list;
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            /*
             1.实例化HttpClient[设置要请求的URI]

             */
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57991/api/Student/");
                //Http Post
                var postTask = client.PostAsJsonAsync<StudentViewModel>("student", student);
                postTask.Wait();//等待执行结束
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "系统错误请联系管理员!");
            return View(student);
        }
    }
}