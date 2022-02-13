using Blog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repositories
{
#pragma warning disable

    public partial class BaseRepository<T>: IAsyncRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal readonly DbSet<T> _table;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await  _context.SaveChangesAsync();

            return entity;
        }
        public async Task<T> DeleteAsync(T entity)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
