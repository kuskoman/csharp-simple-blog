using System.ComponentModel.DataAnnotations;
using SimpleBlog.Models;

namespace SimpleBlog.Dto
{
    public class PostCreateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;
    }

    public class PostModifyDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
    }

    public class PostShowDto
    {
        public uint Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public AuthorResponseDto? Author { get; set; }
        public CommentShowDto[] Comments { get; set; }

        public PostShowDto(Post post)
        {
            Id = post.Id;
            Title = post.Title!;
            Content = post.Body!;
            Author = GetAuthorIfNotNull(post);
            Comments = GetCommentsIfNotNull(post);
        }

        private static CommentShowDto[] GetCommentsIfNotNull(Post post)
        {
            if (post.Comments == null)
            {
                return Array.Empty<CommentShowDto>();
            }

            return post.Comments.Select(c => new CommentShowDto(c)).ToArray();
        }

        private static AuthorResponseDto? GetAuthorIfNotNull(Post post)
        {
            if (post.Author == null)
            {
                return null;
            }

            return new AuthorResponseDto(post.Author);
        }
    }
}
