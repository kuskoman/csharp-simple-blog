using SimpleBlog.Controllers;
using SimpleBlog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SimpleBlog.Models;
using SimpleBlog.Dto;
using Microsoft.Extensions.Logging;
using System.Net;

namespace SimpleBlog.Tests
{
    public class UsersControllerTest
    {
        private readonly UsersController _controller;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<UserManager<User>> _userManagerMock;

        public UsersControllerTest()
        {
            var logger = new Mock<ILogger<UsersController>>().Object;
            var store = new Mock<IUserStore<User>>();
            _userServiceMock = new Mock<IUserService>();
            _userManagerMock = new Mock<UserManager<User>>(
                store.Object,
                // i love C#
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
            );
            _controller = new UsersController(
                logger,
                _userServiceMock.Object,
                _userManagerMock.Object
            );
        }

        [Fact]
        public void Get_WithValidId_ReturnsOk()
        {
            var user = new User();
            var expectedHttpCode = (int)HttpStatusCode.OK;
            _userServiceMock.Setup(x => x.Get(1)).Returns(user);

            var result = _controller.Get(1);

            Assert.IsType<ActionResult<UserResponseDto>>(result);
            var okResult = result.Result as OkObjectResult;
            Assert.Equal(expectedHttpCode, okResult?.StatusCode ?? 0);
        }
    }
}
