using Blog.Application.Features.Posts.Commands.Create;
using Blog.Application.Features.Posts.Commands.Delete;
using Blog.Application.Features.Posts.Commands.Update;
using Blog.Application.Features.Posts.Queries.GetPostDetail;
using Blog.Application.Features.Posts.Queries.GetPosts;
using Blog.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetPosts")]
        [HttpHead]
        public async Task<ActionResult<List<GetPostsViewModel>>> GetAllPosts()
        {
            var posts = await _mediator.Send(new GetPostsQuery());
            return Ok(posts);
        }

        [HttpGet("{id}", Name = "GetPostById")]
        public async Task<ActionResult<GetPostViewModel>> GetPostById(Guid id)
        {
            var getEventDetailQuery = new GetPostQuery() { PostId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddPost")]
        public async Task<ActionResult<CreatePostCommand>> Create([FromBody] CreatePostCommand createPostCommand)
        {
            return Ok(await _mediator.Send(createPostCommand));
        }

        [HttpPut("{id}", Name = "UpdatePost")]
        public async Task<ActionResult<UpdatePostCommand>> Update([FromBody] UpdatePostCommand updatePostCommand)
        {
            var updated = await _mediator.Send(updatePostCommand);
            return Ok(updated);
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePostCommand = new DeletePostCommand() { PostId = id };
            await _mediator.Send(deletePostCommand);
            return NoContent();
        }
    }
}
