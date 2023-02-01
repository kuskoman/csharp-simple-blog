using SimpleBlog.Models.Interfaces;

namespace SimpleBlog.Models
{
    public class Comment : IModel
    {
        public uint Id { get; set; }
        public string? Body { get; set; }
        public Post? Post { get; set; }
        public User? Author { get; set; }
    }
}
