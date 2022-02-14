using Blog.Application.Interfaces;
using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Persistence.Repositories
{
#pragma warning disable

    public class PostRepository : BaseRepository<Post>, IPostRepository 
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(Expression<Func<Post, bool>>? filter = null, params Expression<Func<Post, object>>[] includeProperties)
        {
            IQueryable<Post> query = _table;  
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties)
                {
                    query = query.Include(includeProp);
                }

            }

            return await query.ToListAsync();
         
        }

        public async Task<Post> GetPostByIdAsync(Guid id, bool tracked = true, params Expression<Func<Post, object>>[] includeProperties)
        {
            if (tracked)
            {
                IQueryable<Post> query = _table;
 

                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties)
                    {
                        query = query.Include(includeProp);
                    }
                }

                return await query.FirstOrDefaultAsync(x => x.Id == id);
            }
            else
            {
                IQueryable<Post> query = _table.AsNoTracking();
 
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties)
                    {
                        query = query.Include(includeProp);
                    }
                }

                return await query.FirstOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}
