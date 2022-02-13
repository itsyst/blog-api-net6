using Blog.Application.Interfaces;
using MediatR;

namespace Blog.Application.Features.Posts.Commands.Delete
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IPostRepository _postRepository;
        public DeletePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetPostByIdAsync(request.PostId);  
            await _postRepository.DeleteAsync(post);
            return Unit.Value;
        }
    }
}
