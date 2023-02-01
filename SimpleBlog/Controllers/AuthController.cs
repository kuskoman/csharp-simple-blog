using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Dto;
using Microsoft.AspNetCore.Authorization;

namespace SimpleBlog.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("signup")]
        [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status201Created)]
        [ProducesResponseType(
            typeof(RegisterErrorResponseDto),
            StatusCodes.Status422UnprocessableEntity
        )]
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

        [HttpPost("login")]
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

        [HttpPost("logout")]
        public async Task<ActionResult> Signout()
        {
            await _authService.Signout();
            return Ok();
        }
    }
}
