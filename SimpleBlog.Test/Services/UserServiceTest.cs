using SimpleBlog.Repositories.Interfaces;
using SimpleBlog.Models;
using SimpleBlog.Services;
using SimpleBlog.Services.Interfaces;

namespace SimpleBlog.Test.Services
{
    public class UserServiceTest : IClassFixture<UserServiceFixture>
    {
        IUserService Service { get; }
        Mock<IUserRepository> RepoMock { get; }

        public UserServiceTest(UserServiceFixture fixture)
        {
            Service = fixture.Service;
            RepoMock = fixture.RepoMock;
        }

        [Fact]
        public void TestGetByEmailExistingUser()
        {
            var mockedUser = new User() { Email = "email@example.com" };

            RepoMock.Setup(repo => repo.GetByEmail(It.IsAny<string>())).Returns(mockedUser);

            var returnedUser = Service.GetByEmail(mockedUser.Email);
            Assert.Equal(returnedUser, mockedUser);
            RepoMock.Verify(
                repo => repo.GetByEmail(It.Is<string>(arg => arg.Equals(mockedUser.Email))),
                Times.Once
            );
        }

        [Fact]
        public void TestGetByEmailInvalidUser()
        {
            var mockedUser = new User() { Email = "email@example.com" };

            RepoMock.Setup(repo => repo.GetByEmail(It.IsAny<string>())).Returns<User?>(null);

            var invalidEmail = "invalid email";
            var returnedUser = Service.GetByEmail(invalidEmail);
            Assert.Null(returnedUser);
            RepoMock.Verify(
                repo => repo.GetByEmail(It.Is<string>(arg => arg.Equals(invalidEmail))),
                Times.Once
            );
        }
    }

    public class UserServiceFixture
    {
        public Mock<IUserRepository> RepoMock { get; }
        public IUserService Service { get; }

        public UserServiceFixture()
        {
            RepoMock = new Mock<IUserRepository>();
            Service = new UserService(RepoMock.Object);
        }
    }
}
