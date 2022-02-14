using Blog.Application.Interfaces;
using Blog.Domain;
using Microsoft.EntityFrameworkCore;
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
                if(_context.Database.GetPendingMigrations().Any())
                    _context.Database.Migrate();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
            }

            // Create categories
            if (!_context.Categories.Any())
            {
                _context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Id = Guid.Parse("{6626ca37-6e94-4a28-ae57-742ba0ec23e6}"),
                            Name = "First category."
                        }
                    });
                _context.SaveChanges();
            }

            // Create posts
            if (!_context.Posts.Any())
            {
                _context.Posts.AddRange(new List<Post>()
                    {
                        new Post()
                        {
                            Id = Guid.Parse("{1516e9e4-f235-45af-a93c-e1fb9a0d5225}"),
                            Title = "First Tile blog post.",
                            ImageUrl = "https://source.unsplash.com/random/600x200/?posts",
                            Excerpt = "Lorem ipsum dolor sit amet",
                            Content = "First Content blog post.",
                            CreatedAt = DateTime.UtcNow,
                         }
                    });
                _context.SaveChanges();
            }

            // Create Tags
            if (!_context.Tags.Any())
            {
                _context.Tags.AddRange(new List<Tag>()
                    {
                        new Tag()
                        {
                            Id = Guid.Parse("{b4c23068-9081-4506-a6a3-1db00d63f7c2}"),
                            Name = "First Tag blog post.",
                            PostId = Guid.Parse("{1516e9e4-f235-45af-a93c-e1fb9a0d5225}"),
                        }
                    });
                _context.SaveChanges();
            }

            // Create Comments
            if (!_context.Comments.Any())
            {
                _context.Comments.AddRange(new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = Guid.Parse("{b2fcc163-58d2-46b9-8b9c-432783785693}"),
                            Content = "First Comment blog post.",
                            CreatedAt = DateTime.UtcNow.AddDays(1),
                            PostId = Guid.Parse("{1516e9e4-f235-45af-a93c-e1fb9a0d5225}"),
                        }
                    });
                _context.SaveChanges();
            }

            return;
        }
    }
}
