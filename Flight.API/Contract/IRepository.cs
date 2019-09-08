using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.API.Contract
{
   public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Login(string UserName, String Password);

    }
}
