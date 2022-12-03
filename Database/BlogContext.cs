using Microsoft.EntityFrameworkCore;
using SimpleBlog.Models;

namespace SimpleBlog.Database
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
