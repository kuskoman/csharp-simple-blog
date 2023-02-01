using SimpleBlog.Models;

namespace SimpleBlog.Repositories.Interfaces
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        public Post? GetWithCommentsAndAuthor(uint id);
        public List<Post> GetAllWithCommentsAndAuthor();
    }
}
