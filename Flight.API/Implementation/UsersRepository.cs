using Flight.API.Contract;
using Flight.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.API.Implementation
{
    public class UsersRepository : IRepository<Users>
    {
        readonly FlightManagmentContext _Context;
        public UsersRepository(FlightManagmentContext context)
        {
            _Context = context;
        }

        public IEnumerable<Users> GetAll()
        {
            return _Context.Users.ToList();
        }

        public IEnumerable<Users> Login(string UserName, string Password)
        {
            return _Context.Users.Include(x => x.Role).Where(x => x.UserName == UserName && x.Password == Password).ToList();
                //_Context.Roles.Include(x => x.Users.Where(y => y.UserName == UserName && y.Password == Password)).ToList();
        }
    }
}
