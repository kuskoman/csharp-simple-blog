using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Dto;
using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(
            ILogger<AuthController> logger,
            IAuthService authService,
            IUserService userService
        )
        {
            _logger = logger;
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("signup")]
        [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<User>> Register([FromBody] UserCreateDto user)
        {
            _logger.LogTrace($"Received login request for user {user.Email}");
            var signupResult = await _authService.Signup(user);
            if (!signupResult.Succeeded)
            {
                return UnprocessableEntity(signupResult);
            }
            return Created("", signupResult);
        }
    }
}
