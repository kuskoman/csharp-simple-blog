using SimpleBlog.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models
{
    public class Post : IModel
    {
        public uint Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Body { get; set; } = string.Empty;

        [Required]
        public User? Author { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
