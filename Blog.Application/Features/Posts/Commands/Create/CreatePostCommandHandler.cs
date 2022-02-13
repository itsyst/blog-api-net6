using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Features.Posts.Commands.Create
{
    public class UpdatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }


        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = _mapper.Map<Post>(request);

            CreatePostCommandValidator validator = new();
            var result = await validator.ValidateAsync(request, cancellationToken);

            if (result.Errors.Any())
                throw new Exception("Post is not valid");

            post = await _postRepository.AddAsync(post);

            return post.Id;
        }
    }
}
