using System.ComponentModel.DataAnnotations;

namespace Blog.Domain
{
    public class Post
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


        public Category Category { get; set; } = new Category();
        public Guid CategoryId { get; set; }


        public ICollection<Tag> Tags { get; } = new List<Tag>();

        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
