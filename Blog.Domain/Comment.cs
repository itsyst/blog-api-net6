using System.ComponentModel.DataAnnotations;

namespace Blog.Domain
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}