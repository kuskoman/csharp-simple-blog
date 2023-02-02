using SimpleBlog.Models;

namespace SimpleBlog.Services.Interfaces
{
    public interface ICommentService
    {
        public List<Comment> GetCommentsForPost(uint postId);
        public Comment CreateCommentForPost(uint postId, Comment comment);
        public Comment DeleteComment(uint commentId);
    }
}
