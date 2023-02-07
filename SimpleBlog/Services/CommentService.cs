using SimpleBlog.Database;
using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Repositories.Interfaces;
using SimpleBlog.Dto;

namespace SimpleBlog.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public List<Comment> GetCommentsForPost(uint postId)
        {
            var comments = _repository.GetCommentsForPost(postId);
            return comments;
        }

        public Comment CreateCommentForPost(uint postId, User author, CommentCreateDto comment)
        {
            var createdComment = _repository.CreateCommentForPost(postId, author, comment);
            return createdComment;
        }

        public Comment DeleteComment(uint commentId)
        {
            var comment = _repository.Delete(commentId);
            return comment;
        }
    }
}
