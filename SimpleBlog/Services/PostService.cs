using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Repositories.Interfaces;

namespace SimpleBlog.Services
{
    public class PostService : BaseService<Post>, IPostService
    {
        new protected IPostRepository _repository { get; set; }

        public PostService(IPostRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Post? GetWithCommentsAndAuthor(uint id)
        {
            var post = _repository.GetWithCommentsAndAuthor(id);
            return post;
        }

        public List<Post> GetAllWithCommentsAndAuthor()
        {
            var posts = _repository.GetAllWithCommentsAndAuthor();
            return posts;
        }
    }
}
