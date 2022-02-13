using AutoMapper;
using Blog.Application.Interfaces;
using MediatR;

namespace Blog.Application.Features.Posts.Queries.GetPosts
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<GetPostsViewModel>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostsQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<List<GetPostsViewModel>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAllPostsAsync(filter:null, p => p.Category, p => p.Comments, p => p.Tags);
            return _mapper.Map<List<GetPostsViewModel>>(posts.OrderByDescending(p=>p.CreatedAt));
        }
    }
}
