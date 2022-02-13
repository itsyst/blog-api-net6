using MediatR;

namespace Blog.Application.Features.Posts.Commands.Delete
{
    public class DeletePostCommand : IRequest
    {
        public Guid PostId { get; set; }
    }
}
