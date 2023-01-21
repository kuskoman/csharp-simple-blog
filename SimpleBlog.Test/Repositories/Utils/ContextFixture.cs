using SimpleBlog.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SimpleBlog.Test.Repositories.Utils
{
    public class DbContextFixture : IDisposable
    {
        public BlogContext Context { get; }

        public DbContextFixture()
        {
            var dbNameSuffix = RandomString(15);
            var contextOptions = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase($"DbContextFixture-{dbNameSuffix}")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            Context = new BlogContext(contextOptions);

            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        private static readonly Random Random = new Random();

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(
                Enumerable.Repeat(chars, length).Select(s => s[Random.Next(s.Length)]).ToArray()
            );
        }
    }
}
