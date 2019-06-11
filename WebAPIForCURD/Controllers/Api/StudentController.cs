using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIForCURD.Models;

namespace WebAPIForCURD.Controllers.Api
{
    /// <summary>
    /// Web API 增删查改
    /// 1.前面我们学过，方法以Get或者Get作为前缀，Web API就将其视为Get 请求的方法
    /// 2.我们不应该直接从Web API返回EF实体对象，推荐DTO（Data Transfer Object）数据传输对象。
    /// 3.请注意：ViewModel classes或者DTO classes仅仅是用于把数据从Web API控制器传递给客户端。你可以按照你自己的方式命名。
    /// 4.下面的两个注释的方法GetAllStudents()和GetAllStudentsWithGrade()，我们在编译的时候，不会报错，
    /// 但是运行的时候，就会报错，因为Web API不知道该执行哪个方法。
    /// 【找到了与该请求匹配的多个操作: 类型 WebAPIForCURD.Controllers.StudentController 
    /// 的 GetAllStudents 类型 WebAPIForCURD.Controllers.StudentController 的 GetAllStudentsWithGrade】；
    /// 5.多个Get方法：Web API 可以包含多个Get方法，这些方法有不同的参数以及不同的类型
    /// 6.POST 请求用于创建一个新的记录,同Get方法类似，POST方法名称要么是POST要么是POST最为前缀，不然的话就要标识HttpPost特性
    /// </summary>
    public class StudentController : ApiController
    {
        #region Get 类型的方法
        #region 获取所有的Student记录
        /// <summary>
        /// 获取所有的Student记录
        /// </summary>
        /// <returns></returns>
        //public IHttpActionResult GetAllStudents()
        //{
        //    //不应该直接返回EF对象，而应该返回DTO或者ViewModel对象
        //    IList<StudentViewModel> students = null;
        //    using (var db = new EFDemoDBEntities())
        //    {
        //        students = db.Students.Include("Grades").Select(s => new StudentViewModel()
        //        {
        //            ID = s.ID,
        //            Name = s.Name,
        //            Sex = s.Sex,
        //            Age = s.Age

        //        }).ToList<StudentViewModel>();
        //    }
        //    //count数量为0，说明没有数据
        //    if (students.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(students);
        //}
        #endregion

        #region 获取所有的Student记录【包含Grade信息】
        /// <summary>
        /// 获取所有的Student记录【包含Grade信息】
        /// </summary>
        /// <returns></returns>
        //public IHttpActionResult GetAllStudentsWithGrade()
        //{
        //    IList<StudentViewModel> students = null;
        //    using (var db = new EFDemoDBEntities())
        //    {
        //        students = db.Students.Include("Grades").Select(s => new StudentViewModel()
        //        {
        //            ID = s.ID,
        //            Name = s.Name,
        //            Sex = s.Sex,
        //            Age = s.Age,
        //            Grade = s.Grade == null ? null : new GradeViewModel()
        //            {
        //                GradeID = s.Grade.GradeID,
        //                GradeName = s.Grade.GradeName
        //            }
        //        }).ToList<StudentViewModel>();
        //    }
        //    if (students.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(students);
        //} 
        #endregion

        #region 获取所有的Student记录，根据参数是否包含Grade信息
        /// <summary>
        /// 获取所有的Student记录，根据参数是否包含Grade信息
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAllStudents(bool includeGrade = false)
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
                    Age = s.Age,
                    Grade = s.Grade == null || includeGrade == false ? null : new GradeViewModel()
                    {
                        GradeID = s.Grade.GradeID,
                        GradeName = s.Grade.GradeName
                    }
                }).ToList<StudentViewModel>();
            }
            //count数量为0，说明没有数据
            if (students.Count == 0)
            {
                return NotFound();
            }
            return Ok(students);
        }
        #endregion

        #region 根据id查询学生
        /// <summary>
        /// 根据id查询学生
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetStudentById(int id)
        {
            StudentViewModel student = null;
            using (var db = new EFDemoDBEntities())
            {
                student = db.Students.Include("Grades").Where(s => s.ID == id).Select(s => new StudentViewModel()
                {
                    ID = s.ID,
                    Name = s.Name,
                    Sex = s.Sex,
                    Age = s.Age

                }).FirstOrDefault<StudentViewModel>();
            }
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        #endregion

        #region 根据name查询学生信息
        /// <summary>
        /// 根据name查询学生信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IHttpActionResult GetAllStudents(string name)
        {
            IList<StudentViewModel> students = null;
            using (var db = new EFDemoDBEntities())
            {
                students = db.Students.Include("Grades").Where(s => s.Name.ToLower() == name.ToLower()).
                    Select(s => new StudentViewModel()
                    {
                        ID = s.ID,
                        Name = s.Name,
                        Sex = s.Sex,
                        Age = s.Age
                    }).ToList<StudentViewModel>();
            }
            if (students.Count == 0)
            {
                return NotFound();
            }
            return Ok(students);
        }
        #endregion

        #region 获取一个班级中的Student
        /// <summary>
        /// 获取一个班级中的Student
        /// </summary>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public IHttpActionResult GetAllStudentsInSameGrade(int gradeId)
        {
            IList<StudentViewModel> students = null;
            using (var db = new EFDemoDBEntities())
            {
                students = db.Students.Include("Grades").Where(s => s.Grade.GradeID == gradeId).
                     Select(s => new StudentViewModel()
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
        #endregion
        #endregion


        #region POST 类型的方法

        #region POST,请求，新增一个Student
        /// <summary>
        /// POST,请求，新增一个Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public IHttpActionResult PostNewStudent(StudentViewModel student)
        {
            /*
             在Filder中的request body中这样写：
             {
                "name":"TestStudent",
                "sex":"女",
                "age":"18",
                "Grade":{"gradeid":2,"gradename":"软件1107班"}

             }
             */


            if (student != null)
            {
                if (!ModelState.IsValid)
                {
                    //400
                    return BadRequest("Invalid data");
                }
                using (var db = new EFDemoDBEntities())
                {
                    //因为不要把EF的实体对象和客户端直接操作，就搞一个ViewModel实体
                    db.Students.Add(new Student()
                    {
                        ID = student.ID,
                        Name = student.Name,
                        Sex = student.Sex,
                        Age = student.Age,
                        Grade =null
                        //db.Grades.Where(s => s.GradeID == student.Grade.GradeID).FirstOrDefault()
                        //{ GradeID = student.Grade.GradeID, GradeName = student.Grade.GradeName }//这样写就会新增一个班级
                    });
                    db.SaveChanges();
                }

                return Ok();
            }


            return NotFound();
        }
        #endregion

        #endregion


        #region Put类型的方法

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public IHttpActionResult PutStudent(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            using (var db = new EFDemoDBEntities())
            {
                var existingStudent = db.Students.Where(s => s.ID == student.ID).FirstOrDefault<Student>();
                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Sex = student.Sex;
                    existingStudent.Age = student.Age;
                    db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        #endregion

        #region Delete类型的方法

        public IHttpActionResult DeleteStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid student id");
            }
            using (var db = new EFDemoDBEntities())
            {
                var student = db.Students.Where(s => s.ID == id).FirstOrDefault();
                if (student == null)
                {
                    return NotFound();
                }
                db.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            return Ok();
        }

        #endregion


    }
}
