using Blog.Domain;
using System.Linq.Expressions;

namespace Blog.Application.Interfaces
{
    public interface IPostRepository : IAsyncRepository<Post>
    {
        Task<Post> GetPostByIdAsync(Guid id, string? includeProperties = null, bool tracked = true);
        Task<IReadOnlyList<Post>> GetAllPostsAsync(Expression<Func<Post, bool>>? filter = null, params Expression<Func<Post, object>>[] includeProperties);
    }
}
