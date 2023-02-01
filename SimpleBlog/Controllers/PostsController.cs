using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;
        private readonly IPostService _postService;
        private readonly UserManager<User> _userManager;

        public PostsController(
            ILogger<PostsController> logger,
            IPostService postService,
            UserManager<User> userManager
        )
        {
            _logger = logger;
            _postService = postService;
            _userManager = userManager;
        }

        public ActionResult<IEnumerable<Post>> Index()
        {
            return Ok(_postService.GetAllPostsWithCommentsAndAuthors());
        }

        public ActionResult<Post> Show(uint id)
        {
            var post = _postService.GetPostWithCommentsAndAuthors(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // [Authorize(Roles = "Admin")]
        [HttpPost("")]
        [ProducesResponseType(typeof(Post), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<Post> Create(Post post)
        {
            var user = _userManager.GetUserAsync(User).Result;

            _postService.Create(post);

            return CreatedAtAction(nameof(Show), new { id = post.Id }, post);
        }

        // [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Post> Update(uint id, Post post)
        {
            var existingPost = _postService.Get(id);

            if (existingPost == null)
            {
                return NotFound();
            }

            existingPost.Title = post.Title;
            existingPost.Body = post.Body;

            _postService.Modify(existingPost);

            return Ok(existingPost);
        }

        // [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<Post> Delete(uint id)
        {
            var post = _postService.Get(id);

            if (post == null)
            {
                return NotFound();
            }

            _postService.Delete(post.Id);

            return Ok(post);
        }
    }
}
