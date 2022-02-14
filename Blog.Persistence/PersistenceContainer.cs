using Blog.Application.Interfaces;
using Blog.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>options.UseSqlServer(
                    configuration.GetConnectionString("BlogConnectionString"), 
                    providerOptions => providerOptions.EnableRetryOnFailure()));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IPostRepository), typeof(PostRepository));

            return services;
        }
    }
}
