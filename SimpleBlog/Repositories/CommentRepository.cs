using SimpleBlog.Models;
using SimpleBlog.Database;
using SimpleBlog.Repositories.Interfaces;
using System.Linq;

namespace SimpleBlog.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogContext ctx) : base(ctx, ctx.Comments!) { }

        public List<Comment> GetCommentsForPost(uint postId)
        {
            return _dbSet.Where(c => c.Post.Id == postId).ToList();
        }

        public Comment CreateCommentForPost(uint postId, Comment comment)
        {
            comment.Post.Id = postId;
            return Create(comment);
        }

        public Comment DeleteCommentForPost(uint postId, uint commentId)
        {
            var comment = _dbSet.Find(commentId);
            if (comment == null || comment.Post.Id != postId)
            {
                throw new ArgumentException(
                    $"Could not find comment with id ${commentId} for post with id ${postId}"
                );
            }

            return Delete(commentId);
        }
    }
}
