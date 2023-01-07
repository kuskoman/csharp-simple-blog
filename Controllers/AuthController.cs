using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;
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

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("signup")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<User>> Register([FromBody] UserCreateDto user)
        {
            _logger.LogTrace($"Received login request for user {user.Email}");
            var signupResult = await _authService.Signup(user);
            if (!signupResult.Succeeded)
            {
                return UnprocessableEntity(signupResult);
            }
            return Created("test", signupResult);
        }
    }
}
