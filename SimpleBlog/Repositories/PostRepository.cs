using SimpleBlog.Database;
using SimpleBlog.Models;
using SimpleBlog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SimpleBlog.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        new protected DbSet<Post> _dbSet { get; set; }

        public PostRepository(BlogContext ctx) : base(ctx, ctx.Posts!)
        {
            _dbSet = ctx.Posts!;
        }

        public Post? GetWithCommentsAndAuthor(uint id)
        {
            var post = _dbSet
                .Where(p => p.Id == id)
                .Include(p => p.Author!)
                .Include(p => p.Comments!)
                .ThenInclude(c => c.Author)
                .FirstOrDefault();
            return post;
        }

        public List<Post> GetAllWithCommentsAndAuthor()
        {
            var posts = _dbSet
                .Where(p => p.Id > 0)
                .Include(p => p.Author!)
                .Include(p => p.Comments!)
                .ThenInclude(c => c.Author)
                .ToList();
            posts.Reverse();
            return posts;
        }
    }
}
