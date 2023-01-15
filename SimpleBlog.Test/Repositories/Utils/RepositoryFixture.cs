using SimpleBlog.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SimpleBlog.Test.Repositories.Utils
{
    public class RepositoryFixture<Model> where Model : class
    {
        public Mock<DbSet<Model>> DbSetMock { get; }
        public Mock<BlogContext> ContextMock { get; }

        public RepositoryFixture()
        {
            DbSetMock = new Mock<DbSet<Model>>();
            ContextMock = new Mock<BlogContext>(new DbContextOptions<BlogContext>());
        }
    }

    public class BaseModelMock { }
}
