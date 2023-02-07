using SimpleBlog.Dto;
using SimpleBlog.Models;

namespace SimpleBlog.Repositories.Interfaces
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        public List<Comment> GetCommentsForPost(uint postId);
        public Comment CreateCommentForPost(uint postId, User author, CommentCreateDto comment);
    }
}
