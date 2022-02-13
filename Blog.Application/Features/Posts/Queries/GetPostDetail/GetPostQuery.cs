using MediatR;

namespace Blog.Application.Features.Posts.Queries.GetPostDetail
{
    public class GetPostQuery : IRequest<GetPostViewModel>
    {
        public Guid PostId { get; set; }
    }
}
