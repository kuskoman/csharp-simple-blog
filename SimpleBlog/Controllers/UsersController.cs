using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public UsersController(
            ILogger<UsersController> logger,
            IUserService userService,
            UserManager<User> userManager
        )
        {
            _logger = logger;
            _userService = userService;
            _userManager = userManager;
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

        [HttpGet("me")]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<UserResponseDto> Me()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                _logger.LogWarning("Could not find user for current session");
                return Unauthorized();
            }
            return Ok(new UserResponseDto(user));
        }

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
