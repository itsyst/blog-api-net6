namespace Blog.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}