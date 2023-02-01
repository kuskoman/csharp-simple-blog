using SimpleBlog.Models;

namespace SimpleBlog.Services.Interfaces
{
    public interface IPostService : IBaseService<Post>
    {
        public List<Post> GetAllPostsWithCommentsAndAuthors();
        public Post? GetPostWithCommentsAndAuthors(uint id);
    }
}
