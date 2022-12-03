using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;

namespace SimpleBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userService.GetAll();
        }

        [HttpPost]
        public User Post([FromBody] User user)
        {
            return _userService.Create(user);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] User user) { }

        [HttpDelete("{id}")]
        public void Delete(int id) { }
    }
}
