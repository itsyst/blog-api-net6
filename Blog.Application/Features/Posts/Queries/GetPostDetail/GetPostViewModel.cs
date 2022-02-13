using Blog.Application.Mapping.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Features.Posts.Queries.GetPostDetail
{
    public class GetPostViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public CategoryDto CategoryDto { get; set; } = new CategoryDto();

        public ICollection<TagDto> TagsDto { get; } = new List<TagDto>();

        public ICollection<CommentDto> CommentsDto { get; } = new List<CommentDto>();

    }
}
