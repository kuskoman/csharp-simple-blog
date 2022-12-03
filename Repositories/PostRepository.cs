using SimpleBlog.Database;
using SimpleBlog.Models;
using SimpleBlog.Repositories.Interfaces;

namespace SimpleBlog.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogContext _blogContext;

        public PostRepository(BlogContext ctx)
        {
            _blogContext = ctx;
        }

        public List<Post> GetAll()
        {
            return _blogContext.Posts!.ToList();
        }

        public Post? Get(int id)
        {
            return _blogContext.Posts!.Find(id);
        }

        public Post Delete(int id)
        {
            var dbPost = _blogContext.Posts!.Find(id);
            if (dbPost == null)
            {
                throw new ArgumentException($"Could not find post with id ${id}");
            }

            _blogContext.Remove(dbPost);
            _blogContext.SaveChanges();

            return dbPost;
        }

        public Post Create(Post post)
        {
            _blogContext.Posts!.Add(post);
            _blogContext.SaveChanges();
            return post;
        }

        public Post Modify(Post newPost)
        {
            var oldPost = _blogContext.Posts!.Find(newPost);
            if (oldPost == null)
            {
                throw new ArgumentException("Could not find post with given id");
            }

            _blogContext.Entry(oldPost).CurrentValues.SetValues(newPost);
            _blogContext.SaveChanges();
            return newPost;
        }
    }
}
