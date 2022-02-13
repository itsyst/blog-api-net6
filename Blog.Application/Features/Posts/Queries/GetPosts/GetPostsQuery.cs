using MediatR;

namespace Blog.Application.Features.Posts.Queries.GetPosts
{
    public class GetPostsQuery : IRequest<List<GetPostsViewModel>>
    {
    }
}
