using DependencyInjectWithWebApi.Interface;
using DependencyInjectWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjectWithWebApi.Repository
{
    public class StudentRepository : IRepository
    {
        public IList<Student> GetAll()
        {
            //从数据库中取数据
            List<Student> students = new List<Student>();
            students.Add(new Student() { ID = 1, Name = "张三", Sex = "男", Age = 18 });
            students.Add(new Student() { ID = 2, Name = "李四", Sex = "女", Age = 20 });
            students.Add(new Student() { ID = 3, Name = "王五", Sex = "女", Age = 22 });
            students.Add(new Student() { ID = 4, Name = "钱六", Sex = "男", Age = 20 });
            students.Add(new Student() { ID = 5, Name = "吴七", Sex = "女", Age = 19 });
            students.Add(new Student() { ID = 6, Name = "孙八", Sex = "男", Age = 23 });
            return students;
        }
    }
}