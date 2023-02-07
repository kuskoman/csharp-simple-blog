using SimpleBlog.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models
{
    public class Comment : IModel
    {
        public uint Id { get; set; }

        [Required]
        public string? Body { get; set; }

        [Required]
        public Post? Post { get; set; }

        [Required]
        public User? Author { get; set; }
    }
}
