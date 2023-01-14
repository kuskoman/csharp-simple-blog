using SimpleBlog.Test.Services.Utils;
using SimpleBlog.Repositories.Interfaces;

namespace SimpleBlog.Test.Services
{
    public class BaseServiceTest : IClassFixture<BaseServiceFixture>
    {
        ClassInheritingBaseService Service { get; }
        Mock<IBaseRepository<BaseModelMock>> RepoMock { get; }

        public BaseServiceTest(BaseServiceFixture fixture)
        {
            Service = fixture.Service;
            RepoMock = fixture.RepoMock;
        }

        [Fact]
        public void TestGetAll()
        {
            var repoUsers = new List<BaseModelMock>() { new BaseModelMock() };

            RepoMock.Setup(repo => repo.GetAll()).Returns(repoUsers);

            var returnedUsers = Service.GetAll();
            Assert.Equal(returnedUsers, repoUsers);
            RepoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Fact]
        public void TestGet()
        {
            var modelMock = new BaseModelMock();

            RepoMock.Setup(repo => repo.Get(It.IsAny<uint>())).Returns(modelMock);

            uint userId = 2;
            var returnedUser = Service.Get(userId);
            Assert.Equal(returnedUser, modelMock);
            RepoMock.Verify(repo => repo.Get(It.Is<uint>(arg => arg.Equals(userId))), Times.Once);
        }
    }
}
