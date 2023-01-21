using SimpleBlog.Services;
using SimpleBlog.Repositories.Interfaces;
using SimpleBlog.Repositories;
using SimpleBlog.Database;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Models.Interfaces;

namespace SimpleBlog.Test.Services.Utils
{
    public class BaseModelMock : IModel
    {
        public uint Id { get; set; }
    }

    public class BaseRepositoryMock : BaseRepository<BaseModelMock>
    {
        public BaseRepositoryMock(BlogContext ctx, DbSet<BaseModelMock> dbSet) : base(ctx, dbSet)
        { }
    }

    public class ClassInheritingBaseService : BaseService<BaseModelMock>
    {
        public ClassInheritingBaseService(IBaseRepository<BaseModelMock> repo) : base(repo) { }
    }

    public class BaseServiceFixture
    {
        public Mock<IBaseRepository<BaseModelMock>> RepoMock { get; }
        public ClassInheritingBaseService Service { get; }

        public BaseServiceFixture()
        {
            var repoMock = GetRepositoryMock();
            RepoMock = repoMock;

            var service = new ClassInheritingBaseService(repoMock.Object);
            Service = service;
        }

        private static Mock<IBaseRepository<BaseModelMock>> GetRepositoryMock()
        {
            var repository = new Mock<IBaseRepository<BaseModelMock>>();
            return repository;
        }
    }
}
