using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimpleBlog.Models;

namespace SimpleBlog.Database
{
    public class BlogContext : IdentityDbContext<User, Role, UInt32>
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Post>? Posts { get; set; }
    }
}
