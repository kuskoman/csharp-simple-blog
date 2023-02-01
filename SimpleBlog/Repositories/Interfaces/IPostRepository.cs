using SimpleBlog.Models;

namespace SimpleBlog.Repositories.Interfaces
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        public List<Post> GetAllPostsWithCommentsAndAuthors();
        public Post? GetPostWithCommentsAndAuthors(uint id);
    }
}
