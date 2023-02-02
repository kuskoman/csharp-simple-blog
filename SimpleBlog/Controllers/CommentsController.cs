using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Models;
using SimpleBlog.Dto;
using Microsoft.AspNetCore.Authorization;

namespace SimpleBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentsController(ICommentService service)
        {
            _service = service;
        }

        [HttpPost("{postId}")]
        [ProducesResponseType(typeof(CommentShowDto), 201)]
        [ProducesResponseType(401)]
        public ActionResult<Comment> CreateCommentForPost(uint postId, Comment comment)
        {
            var createdComment = _service.CreateCommentForPost(postId, comment);
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
