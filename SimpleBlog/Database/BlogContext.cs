using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimpleBlog.Models;

namespace SimpleBlog.Database
{
    public class BlogContext : IdentityDbContext<User, Role, uint>
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Post>? Posts { get; set; }
        public DbSet<Comment>? Comments { get; set; }
    }
}
