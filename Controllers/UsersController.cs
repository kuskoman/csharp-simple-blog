using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

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

        [HttpGet("{id:int}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return NotFound($"Could not find user with id ${id}");
            }
            return Ok(user);
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<User>> Index()
        {
            return _userService.GetAll();
        }

        [HttpPost]
        public ActionResult<User> Create([FromBody] User user)
        {
            return Created("test", _userService.Create(user));
        }

        [HttpPut("{id:int}")]
        public User Put([FromBody] User user)
        {
            return _userService.Modify(user);
        }

        [HttpDelete("{id:int}")]
        public User Delete(int id)
        {
            return _userService.Delete(id);
        }
    }
}
