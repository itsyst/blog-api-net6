using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Application.Mapping.Dtos
{
    [Table("Categories")]
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
