using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Repositories.Interfaces;

namespace SimpleBlog.Services
{
    public class PostService : BaseService<Post>, IPostService
    {
        protected new readonly IPostRepository _repository;

        public PostService(IPostRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public List<Post> GetAllPostsWithCommentsAndAuthors()
        {
            return _repository.GetAllPostsWithCommentsAndAuthors();
        }

        public Post? GetPostWithCommentsAndAuthors(uint id)
        {
            return _repository.GetPostWithCommentsAndAuthors(id);
        }
    }
}
