using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjectWithWebApi.Models
{
    public class Student
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public int Age { get; set; }
    }
}