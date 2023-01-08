using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Dto;

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
        public ActionResult<UserResponseDto> Get(uint id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return NotFound($"Could not find user with id ${id}");
            }
            return Ok(new UserResponseDto(user));
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<UserResponseDto>> Index()
        {
            return Ok(_userService.GetAll().Select(u => new UserResponseDto(u)));
        }

        // [HttpGet("me")]
        // public ActionResult<UserResponseDto> Me()
        // {

        // }

        [HttpPost]
        public ActionResult<UserResponseDto> Create([FromBody] User user)
        {
            var createdUser = _userService.Create(user);
            return Created("test", new UserResponseDto(createdUser));
        }

        [HttpPut("{id:int}")]
        public ActionResult<UserResponseDto> Put([FromBody] User user)
        {
            var modifiedUser = _userService.Modify(user);
            return Ok(new UserResponseDto(modifiedUser));
        }

        [HttpDelete("{id:int}")]
        public ActionResult<UserResponseDto> Delete(uint id)
        {
            var deletedUser = _userService.Delete(id);
            return Ok(new UserResponseDto(deletedUser));
        }
    }
}
