using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Application.Mapping.Dtos
{
    [Table("Tags")]
    public class TagDto
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Guid PostId { get; set; }
    }
}
