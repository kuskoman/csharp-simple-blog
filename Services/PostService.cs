using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Repositories.Interfaces;

namespace SimpleBlog.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public List<Post> GetAll()
        {
            return _repository.GetAll();
        }

        public Post? Get(int id)
        {
            return _repository.Get(id);
        }

        public Post Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Post Create(Post post)
        {
            return _repository.Create(post);
        }

        public Post Modify(Post post)
        {
            return _repository.Modify(post);
        }
    }
}
