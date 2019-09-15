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
using Microsoft.Extensions.Logging;

namespace Flight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<Users> _Repository;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IRepository<Users> Repository, ILogger<UsersController> logger)
        {
            _Repository = Repository;
            _logger = logger;
        }
        [Route("Login")]
        [HttpGet]
        public Users Login(string UserName,string Password)
        {
            _logger.LogInformation("Login Method Called");
            var authors = _Repository.Login(UserName,Password);
            return authors;
        }
    }
}