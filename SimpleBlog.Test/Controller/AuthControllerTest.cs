using SimpleBlog.Controllers;
using SimpleBlog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SimpleBlog.Dto;
using Microsoft.Extensions.Logging;
using System.Net;

namespace SimpleBlog.Tests
{
    public class AuthControllerTests
    {
        private readonly AuthController _controller;
        private readonly Mock<IAuthService> _mockAuthService;

        public AuthControllerTests()
        {
            var logger = new Mock<ILogger<AuthController>>().Object;
            _mockAuthService = new Mock<IAuthService>();
            _controller = new AuthController(logger, _mockAuthService.Object);
        }

        [Fact]
        public async Task Register_WithValidUser_ReturnsCreated()
        {
            var user = new UserCreateDto();
            var identityResult = IdentityResult.Success;
            var expectedHttpCode = (int)HttpStatusCode.Created;
            _mockAuthService.Setup(x => x.Signup(user)).ReturnsAsync(identityResult);

            var result = await _controller.Register(user);

            Assert.IsType<ActionResult<IdentityResult>>(result);
            var createdResult = result.Result as CreatedResult;
            Assert.Equal(expectedHttpCode, createdResult?.StatusCode ?? 0);
        }

        [Fact]
        public async Task Register_WithInvalidUser_ReturnsUnprocessableEntity()
        {
            var user = new UserCreateDto();
            var identityResult = IdentityResult.Failed();
            var expectedHttpCode = (int)HttpStatusCode.UnprocessableEntity;
            _mockAuthService.Setup(x => x.Signup(user)).ReturnsAsync(identityResult);

            var result = await _controller.Register(user);

            Assert.IsType<ActionResult<IdentityResult>>(result);
            var unprocessableEntityResult = result.Result as UnprocessableEntityObjectResult;
            Assert.Equal(expectedHttpCode, unprocessableEntityResult?.StatusCode ?? 0);
        }

        // [Fact]
        // public async Task Login_WithValidUser_ReturnsOk()
        // {
        //     var user = new UserLoginDto();
        //     var identityResult = Microsoft.AspNetCore.Identity.SignInResult.Failed;
        //     _mockAuthService.Setup(x => x.Login(user)).ReturnsAsync(identityResult);

        //     var result = await _controller.Login(user);

        //     var okResult = Assert.IsType<OkObjectResult>(result);
        //     Assert.Equal(identityResult, okResult.Value);
        // }

        // [Fact]
        // public async Task Login_WithInvalidUser_ReturnsUnauthorized()
        // {
        //     var user = new UserLoginDto();

        //     var identityResult = Microsoft.AspNetCore.Identity.SignInResult.Failed;
        //     _mockAuthService.Setup(x => x.Login(user)).ReturnsAsync(identityResult);

        //     var result = await _controller.Login(user);

        //     var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
        //     Assert.Equal(identityResult, unauthorizedResult.Value);
        // }

        // [Fact]
        // public async Task RegisterCallsAuthServiceSignup()
        // {
        //     var user = new UserCreateDto();
        //     _mockAuthService.Setup(x => x.Signup(user)).ReturnsAsync(IdentityResult.Success);
        //     var result = await _controller.Register(user);

        //     _mockAuthService.Verify(x => x.Signup(user), Times.Once);
        //     Assert.IsType<CreatedResult>(result);
        // }

        // [Fact]
        // public async Task LoginCallsAuthServiceLogin()
        // {
        //     var user = new UserLoginDto();
        //     _mockAuthService
        //         .Setup(x => x.Login(user))
        //         .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);
        //     var result = await _controller.Login(user);

        //     _mockAuthService.Verify(x => x.Login(user), Times.Once);
        //     Assert.IsType<OkObjectResult>(result);
        // }
    }
}
