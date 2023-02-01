using SimpleBlog.Database;
using SimpleBlog.Models;
using SimpleBlog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SimpleBlog.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(BlogContext ctx) : base(ctx, ctx.Posts!) { }

        public List<Post> GetAllPostsWithCommentsAndAuthors()
        {
            return _dbSet.Include("Comments").Include("Author").ToList();
        }

        public Post? GetPostWithCommentsAndAuthors(uint id)
        {
            return _dbSet
                .Where(post => post.Id == id)
                .Include("Comments")
                .Include("Author")
                .SingleOrDefault();
        }
    }
}
