using Blog.Domain;
using System.Linq.Expressions;

namespace Blog.Application.Interfaces
{
    public interface IPostRepository : IAsyncRepository<Post>
    {
        Task<Post> GetPostByIdAsync(Guid id, bool tracked = true, params Expression<Func<Post, object>>[] includeProperties);
        Task<IReadOnlyList<Post>> GetAllPostsAsync(Expression<Func<Post, bool>>? filter = null, params Expression<Func<Post, object>>[] includeProperties);
    }
}
