using Blog.Application.Mapping.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Features.Posts.Queries.GetPosts
{
    public class GetPostsViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        [Required]
        public string Excerpt { get; set; } = string.Empty;

    }
}
