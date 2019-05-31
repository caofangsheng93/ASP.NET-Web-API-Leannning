using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPIForCURD.Models
{
    /// <summary>
    /// Student视图模型
    /// </summary>
    public class StudentViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public int Age { get; set; }

        public GradeViewModel Grade { get; set; }

    }
}