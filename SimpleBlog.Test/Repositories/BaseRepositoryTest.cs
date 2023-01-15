using SimpleBlog.Repositories.Interfaces;
using SimpleBlog.Repositories;
using SimpleBlog.Database;
using SimpleBlog.Test.Repositories.Utils;
using Microsoft.EntityFrameworkCore;

namespace SimpleBlog.Test.Repositories
{
    public class BaseRepositoryTest : IClassFixture<BaseRepositoryFixture>
    {
        private readonly Mock<DbSet<BaseModelMock>> _dbSetMock;
        private readonly Mock<BlogContext> _contextMock;
        private readonly IBaseRepository<BaseModelMock> _repository;

        public BaseRepositoryTest(BaseRepositoryFixture fixture)
        {
            _dbSetMock = fixture.DbSetMock;
            _contextMock = fixture.ContextMock;
            _repository = new DummyRepository(_contextMock.Object, _dbSetMock.Object);
        }

        [Fact]
        public void TestGetAll()
        {
            var modelsMock = new List<BaseModelMock>() { new BaseModelMock() };
            _dbSetMock.Setup(dbSet => dbSet.ToList()).Returns(modelsMock);

            var returnedModels = _repository.GetAll();
            Assert.Equal(returnedModels, modelsMock);
            _dbSetMock.Verify(dbSet => dbSet.ToList(), Times.Once);
        }
    }

    public class BaseModelMock { }

    public class DummyRepository : BaseRepository<BaseModelMock>, IBaseRepository<BaseModelMock>
    {
        public DummyRepository(BlogContext ctx, DbSet<BaseModelMock> dbSet) : base(ctx, dbSet) { }
    }

    public class BaseRepositoryFixture : RepositoryFixture<BaseModelMock> { }
}
