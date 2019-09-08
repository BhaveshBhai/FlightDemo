using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight.API.Contract;
using Flight.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Flight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<Users> _Repository;
        public UsersController(IRepository<Users> Repository)
        {
            _Repository = Repository;
        }
        [Route("Login")]
        public IActionResult Login(string UserName,string Password)
        {
            var authors = _Repository.Login(UserName,Password);
            return Ok(authors);
        }
    }
}