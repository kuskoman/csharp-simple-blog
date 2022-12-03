using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;

namespace SimpleBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> Get()
        {
            return new List<Post>();
        }

        [HttpPost]
        public void Post([FromBody] Post Post) { }

        [HttpPut("{id}")]
        public void Put([FromBody] Post Post) { }

        [HttpDelete("{id}")]
        public void Delete(int id) { }
    }
}
