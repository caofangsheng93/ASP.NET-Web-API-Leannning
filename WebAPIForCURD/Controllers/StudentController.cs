using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIForCURD.Models;

namespace WebAPIForCURD.Controllers
{
    /// <summary>
    /// Web API 增删查改
    /// 1.前面我们学过，方法以Get或者Get作为前缀，Web API就将其视为Get 请求的方法
    /// 2.我们不应该直接从Web API返回EF实体对象，推荐DTO（Data Transfer Object）数据传输对象。
    /// 3.请注意：ViewModel classes或者DTO classes仅仅是用于把数据从Web API控制器传递给客户端。你可以按照你自己的方式命名。
    /// 4.下面的两个方法GetAllStudents()和GetAllStudentsWithGrade()，我们在编译的时候，不会报错，
    /// 但是运行的时候，就会报错，因为Web API不知道该执行哪个方法。
    /// 【找到了与该请求匹配的多个操作: 类型 WebAPIForCURD.Controllers.StudentController 
    /// 的 GetAllStudents 类型 WebAPIForCURD.Controllers.StudentController 的 GetAllStudentsWithGrade】；
    /// 
    /// 
    /// </summary>
    public class StudentController : ApiController
    {
        /// <summary>
        /// 获取所有的Student记录
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAllStudents()
        {
            //不应该直接返回EF对象，而应该返回DTO或者ViewModel对象
            IList<StudentViewModel> students = null;
            using (var db = new EFDemoDBEntities())
            {
                students = db.Students.Include("Grades").Select(s => new StudentViewModel()
                {
                    ID = s.ID,
                    Name = s.Name,
                    Sex = s.Sex,
                    Age = s.Age

                }).ToList<StudentViewModel>();
            }
            //count数量为0，说明没有数据
            if (students.Count == 0)
            {
                return NotFound();
            }
            return Ok(students);
        }

        public IHttpActionResult GetAllStudentsWithGrade()
        {
            IList<StudentViewModel> students = null;
            using (var db = new EFDemoDBEntities())
            {
                students = db.Students.Include("Grades").Select(s => new StudentViewModel()
                {
                    ID = s.ID,
                    Name = s.Name,
                    Sex = s.Sex,
                    Age = s.Age,
                    Grade = s.Grade == null ? null : new GradeViewModel()
                    {
                        GradeID = s.Grade.GradeID,
                        GradeName = s.Grade.GradeName
                    }
                }).ToList<StudentViewModel>();
            }
            if (students.Count == 0)
            {
                return NotFound();
            }
            return Ok(students);
        }
    }
}
