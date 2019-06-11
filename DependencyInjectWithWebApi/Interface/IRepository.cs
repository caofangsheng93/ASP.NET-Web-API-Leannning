using DependencyInjectWithWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectWithWebApi.Interface
{
   public interface IRepository
    {
        IList<Student> GetAll();
    }
}
