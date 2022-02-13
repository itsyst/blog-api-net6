using System.ComponentModel.DataAnnotations;

namespace Blog.Domain
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Post> Posts { get; set; } = new List<Post>();    
    }
}