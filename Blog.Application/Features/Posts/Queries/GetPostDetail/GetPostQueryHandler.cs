using AutoMapper;
using Blog.Application.Interfaces;
using MediatR;

namespace Blog.Application.Features.Posts.Queries.GetPostDetail
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, GetPostViewModel>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostQueryHandler(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
         }
        public async Task<GetPostViewModel> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetPostByIdAsync(request.PostId, includeProperties: "Comment, Tag, Category");
            return _mapper.Map<GetPostViewModel>(post);
        }
    }
}
