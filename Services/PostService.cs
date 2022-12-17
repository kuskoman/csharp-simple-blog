using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Repositories.Interfaces;

namespace SimpleBlog.Services
{
    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(IPostRepository repository) : base(repository) { }
    }
}
