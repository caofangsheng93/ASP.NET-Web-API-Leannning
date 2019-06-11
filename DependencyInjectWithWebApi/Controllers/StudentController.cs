using DependencyInjectWithWebApi.Interface;
using DependencyInjectWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DependencyInjectWithWebApi.Controllers
{
    public class StudentController : ApiController
    {
        private IRepository _repo;

        public StudentController(IRepository repo)
        {
            _repo = repo;
        }

        public IList<Student> Get()
        {
            return _repo.GetAll();
        }
    }
}
