using SimpleBlog.Models;
using SimpleBlog.Database;
using SimpleBlog.Repositories.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SimpleBlog.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogContext ctx) : base(ctx, ctx.Comments!) { }

        public List<Comment> GetCommentsForPost(uint postId)
        {
            return _dbSet
                .Where(c => c.Post!.Id == postId)
                .AsQueryable()
                .Include(c => c.Author)
                .ToList();
        }

        public Comment CreateCommentForPost(uint postId, Comment comment)
        {
            comment.Post = _ctx.Posts!.Find(postId);
            return Create(comment);
        }
    }
}
