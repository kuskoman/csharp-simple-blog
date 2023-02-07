using SimpleBlog.Models;
using SimpleBlog.Database;
using SimpleBlog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Dto;

namespace SimpleBlog.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly IPostRepository _postRepository;

        public CommentRepository(BlogContext ctx, IPostRepository postRepository)
            : base(ctx, ctx.Comments!)
        {
            _postRepository = postRepository;
        }

        public List<Comment> GetCommentsForPost(uint postId)
        {
            return _dbSet
                .Where(c => c.Post!.Id == postId)
                .AsQueryable()
                .Include(c => c.Author)
                .ToList();
        }

        public Comment CreateCommentForPost(uint postId, User author, CommentCreateDto commentDto)
        {
            var post = _postRepository.Get(postId)!;

            var comment = new Comment()
            {
                Body = commentDto.Body!,
                Post = post,
                Author = author
            };
            return Create(comment);
        }
    }
}
