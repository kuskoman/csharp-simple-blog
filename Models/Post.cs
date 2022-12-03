namespace SimpleBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public string? Slug { get; set; }
        public User? Author { get; set; }
    }
}
