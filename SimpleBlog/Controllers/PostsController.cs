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

        [HttpGet("")]
        public ActionResult<IEnumerable<PostShowDto>> Index()
        {
            var posts = _postService.GetAllWithCommentsAndAuthor();

            return Ok(posts.Select(p => new PostShowDto(p)));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(PostShowDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PostShowDto> Show(uint id)
        {
            var post = _postService.GetWithCommentsAndAuthor(id);

            if (post == null)
            {
                return NotFound($"Could not find post with id ${id}");
            }

            return Ok(new PostShowDto(post));
        }

        // [Authorize(Roles = "Admin")]
        [Authorize]
        [HttpPost("")]
        [ProducesResponseType(typeof(PostShowDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<PostShowDto> Create(PostCreateDto postDto)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (user == null)
            {
                _logger.LogError("Could not find user for current session");
                return Unauthorized();
            }

            var post = new Post
            {
                Title = postDto.Title,
                Body = postDto.Content,
                Author = user
            };

            _postService.Create(post);

            return CreatedAtAction(nameof(Show), new { id = post.Id }, new PostShowDto(post));
        }

        // [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(PostShowDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PostShowDto> Update(uint id, PostModifyDto postDto)
        {
            var existingPost = _postService.Get(id);

            if (existingPost == null)
            {
                return NotFound();
            }

            existingPost.Title = postDto.Title;
            existingPost.Body = postDto.Content;

            var modifiedPost = _postService.Modify(existingPost);
            return Ok(new PostShowDto(modifiedPost));
        }

        // [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<PostShowDto> Delete(uint id)
        {
            var post = _postService.Get(id);

            if (post == null)
            {
                return NotFound();
            }

            _postService.Delete(post.Id);

            return Ok(new PostShowDto(post));
        }
    }
}
