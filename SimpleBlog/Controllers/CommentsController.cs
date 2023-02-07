using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Models;
using SimpleBlog.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;
        private readonly UserManager<User> _userManager;

        public CommentsController(ICommentService service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpPost("{postId}")]
        [ProducesResponseType(typeof(CommentShowDto), 201)]
        [ProducesResponseType(401)]
        public ActionResult<Comment> CreateCommentForPost(uint postId, CommentCreateDto commentDto)
        {
            var user = _userManager.GetUserAsync(User).Result!;
            var createdComment = _service.CreateCommentForPost(postId, user, commentDto);
            return Created("", new CommentShowDto(createdComment));
        }

        [HttpDelete("{commentId}")]
        [ProducesResponseType(typeof(CommentShowDto), 200)]
        [ProducesResponseType(401)]
        public ActionResult<Comment> DeleteComment(uint commentId)
        {
            var comment = _service.DeleteComment(commentId);
            return Ok(new CommentShowDto(comment));
        }
    }
}
