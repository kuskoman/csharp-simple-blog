using SimpleBlog.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SimpleBlog.Test.Repositories.Utils
{
    public class DbContextFixture
    {
        public BlogContext Context { get; }

        public DbContextFixture()
        {
            var dbName = RandomString(15);
            var contextOptions = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase($"DbContextFixture-{dbName}")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            Context = new BlogContext(contextOptions);

            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }

        private static readonly Random s_random = new Random();

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(
                Enumerable.Repeat(chars, length).Select(s => s[s_random.Next(s.Length)]).ToArray()
            );
        }
    }
}
