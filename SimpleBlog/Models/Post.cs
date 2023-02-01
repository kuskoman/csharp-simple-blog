using SimpleBlog.Models.Interfaces;

namespace SimpleBlog.Models
{
    public class Post : IModel
    {
        public uint Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public User? Author { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
