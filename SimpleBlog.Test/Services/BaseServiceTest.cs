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

        [Fact]
        public void TestDelete()
        {
            var modelMock = new BaseModelMock();

            RepoMock.Setup(repo => repo.Delete(It.IsAny<uint>())).Returns(modelMock);

            uint userId = 2;
            var returnedUser = Service.Delete(userId);
            Assert.Equal(returnedUser, modelMock);
            RepoMock.Verify(
                repo => repo.Delete(It.Is<uint>(arg => arg.Equals(userId))),
                Times.Once
            );
        }

        [Fact]
        public void TestCreate()
        {
            var createModelMock = new BaseModelMock();
            var returnedModelMock = new BaseModelMock();

            RepoMock
                .Setup(repo => repo.Create(It.IsAny<BaseModelMock>()))
                .Returns(returnedModelMock);

            var returnedUser = Service.Create(createModelMock);
            Assert.Equal(returnedUser, returnedModelMock);
            RepoMock.Verify(
                repo => repo.Create(It.Is<BaseModelMock>(arg => arg.Equals(createModelMock))),
                Times.Once
            );
        }

        [Fact]
        public void TestModify()
        {
            var createModelMock = new BaseModelMock();
            var returnedModelMock = new BaseModelMock();

            RepoMock
                .Setup(repo => repo.Modify(It.IsAny<BaseModelMock>()))
                .Returns(returnedModelMock);

            var returnedUser = Service.Modify(createModelMock);
            Assert.Equal(returnedUser, returnedModelMock);
            RepoMock.Verify(
                repo => repo.Modify(It.Is<BaseModelMock>(arg => arg.Equals(createModelMock))),
                Times.Once
            );
        }
    }
}
