using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight.API.Models;

namespace Flight.API.Contract
{
   public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Users Login(string UserName, String Password);
    }
}
