using SimpleBlog.Models;

namespace SimpleBlog.Services.Interfaces
{
    public interface IPostService : IBaseService<Post>
    {
        public Post? GetWithCommentsAndAuthor(uint id);
        public List<Post> GetAllWithCommentsAndAuthor();
    }
}
