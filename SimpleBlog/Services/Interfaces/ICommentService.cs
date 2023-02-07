using SimpleBlog.Dto;
using SimpleBlog.Models;

namespace SimpleBlog.Services.Interfaces
{
    public interface ICommentService
    {
        public List<Comment> GetCommentsForPost(uint postId);
        public Comment CreateCommentForPost(uint postId, User author, CommentCreateDto comment);
        public Comment DeleteComment(uint commentId);
    }
}
