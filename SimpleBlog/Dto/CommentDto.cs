using SimpleBlog.Models;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Dto
{
    public class CommentCreateDto
    {
        [Required]
        public string Body { get; set; } = string.Empty;

        [Required]
        public uint PostId { get; set; }
    }

    public class CommentShowDto
    {
        public uint Id { get; set; }
        public string Body { get; set; } = string.Empty;
        public AuthorResponseDto? Author { get; set; }

        public CommentShowDto(Comment comment)
        {
            Id = comment.Id;
            Body = comment.Body!;

            Author = new AuthorResponseDto(comment.Author!);
        }
    }
}
