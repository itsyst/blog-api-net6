using Blog.Application.Interfaces;
using Blog.Domain;
using Microsoft.Extensions.Logging;

namespace Blog.Persistence
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ApplicationDbContext> _logger;

        public DbInitializer(ApplicationDbContext context, ILogger<ApplicationDbContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                _context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
            }

            // Create covers
            if (!_context.Posts.Any())
            {
                var postGuidOne = Guid.Parse("{6315579F-7837-473A-A4D5-A5571B43E6A6}");
                var categoryIdGuidOne = Guid.Parse("{6315579F-7837-473A-KHS2-A5571B43E6A6}");

                var postGuidTwo = Guid.Parse("{C0788D5F-8003-43C1-92A4-EDC76A7C5DDE}");
                var categoryIdGuidTwo = Guid.Parse("{6315579F-7837-473A-KHS2-R89E1B43T22R}");



                _context.Posts.AddRange(new List<Post>()
                    {
                        new Post()
                        {
                            Id = postGuidOne,
                            Title = "First Tile blog post.",
                            ImageUrl = "https://source.unsplash.com/random/600x200/?posts",
                            Excerpt = "Lorem ipsum dolor sit amet",
                            Content = "First Content blog post.",
                            CategoryId = categoryIdGuidOne,
                            CreatedAt = DateTime.Parse("2022-13-02")
                        },
                        new Post()
                        {
                            Id = postGuidTwo,
                            Title = "First Tile blog post.",
                            ImageUrl = "https://source.unsplash.com/random/600x200/?posts",
                            Excerpt = "Lorem ipsum dolor sit amet",
                            Content = "First Content blog post.",
                            CategoryId = categoryIdGuidTwo,
                            CreatedAt = DateTime.Parse("2022-13-03")
                        }
                    });
                _context.SaveChanges();
            }
            return;
        }
    }
}
