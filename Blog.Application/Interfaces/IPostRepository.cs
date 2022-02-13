using Blog.Domain;
using System.Linq.Expressions;

namespace Blog.Application.Interfaces
{
    public interface IPostRepository : IAsyncRepository<Post>
    {
        Task<Post> GetPostByIdAsync(Guid id, Expression<Func<Post, bool>>? filter = null, string? includeProperties = null, bool tracked = true);
        Task<IReadOnlyList<Post>> GetAllPostsAsync(Expression<Func<Post, bool>>? filter = null, params Expression<Func<Post, object>>[] includeProperties);
    }
}
