using MediatR;

namespace Blog.Application.Features.Posts.Commands.Update
{
    public class UpdatePostCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        public string Excerpt { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Guid CategoryId { get; set; }
    }
}
