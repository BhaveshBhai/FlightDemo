using Flight.API.Contract;
using Flight.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.API.Implementation
{
    public class UsersRepository : IRepository<Users>
    {
        readonly FlightManagmentContext _Context;
        readonly ILogger<UsersRepository> _logger;
        public UsersRepository(FlightManagmentContext context, ILogger<UsersRepository> logger)
        {
            _Context = context;
            _logger = logger;
        }

        public IEnumerable<Users> GetAll()
        {
            return _Context.Users.ToList();
        }

        public Users Login(string UserName, string Password)
        {
            var users = new Users();
            try
            {
                var output = _Context.Users.Include(x => x.Role).Where(x => x.UserName == UserName && x.Password == Password).ToList();
                foreach (var a in output)
                {
                    users.Id = a.Id;
                    users.RoleName = a.Role.RoleName;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Got exception.");
            }
           
            return users;
        }
    }
}
