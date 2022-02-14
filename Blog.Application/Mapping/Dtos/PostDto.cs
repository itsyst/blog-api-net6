using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Mapping.Dtos
{
    public class PostDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        [Required]
        public string Excerpt { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;


        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<CategoryDto> CategoriesDto { get; } = new List<CategoryDto>();

        public ICollection<TagDto> Tags { get; } = new List<TagDto>();

        public ICollection<CommentDto> CommentsDto { get; } = new List<CommentDto>();

    }
}
