using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IAuditableEntity
    {
        protected readonly AppDbContext _context;
        protected readonly ILogger _logger;

        public BaseRepository(AppDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<T>> GetByIdsAsync(List<Guid> ids)
        {
            return await _context.Set<T>().Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public IQueryable<T> GetSlice(int skip, int take)
        {
            return _context.Set<T>().Skip(skip).Take(take);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
