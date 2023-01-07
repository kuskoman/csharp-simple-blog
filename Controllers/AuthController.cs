using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Dto;

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
        public async Task<ActionResult<IdentityResult>> Register([FromBody] UserCreateDto user)
        {
            _logger.LogTrace($"Received signup request for user {user.Email}");
            var signupResult = await _authService.Signup(user);
            if (!signupResult.Succeeded)
            {
                return UnprocessableEntity(signupResult);
            }
            return Created("", signupResult);
        }

        [HttpPost("signup")]
        [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Microsoft.AspNetCore.Identity.SignInResult>> Login(
            [FromBody] UserLoginDto loginDto
        )
        {
            _logger.LogTrace($"Received login request for user {loginDto.Email}");
            var loginResult = await _authService.Login(loginDto);
            if (!loginResult.Succeeded)
            {
                return Unauthorized(loginResult);
            }

            return Ok(loginResult);
        }
    }
}
