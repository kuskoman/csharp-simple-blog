using SimpleBlog.Models;

namespace SimpleBlog.Repositories.Interfaces
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        public List<Comment> GetCommentsForPost(uint postId);
        public Comment CreateCommentForPost(uint postId, Comment comment);
        public Comment DeleteCommentForPost(uint postId, uint commentId);
    }
}
