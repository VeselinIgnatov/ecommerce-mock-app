using Domain;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class, IAuditableEntity
    {
        public Task<T> GetByIdAsync(Guid id);
        public Task<List<T>> GetByIdsAsync(List<Guid> id);
        public IQueryable<T> GetAll();
        public IQueryable<T> GetSlice(int skip, int take);
        public Task AddAsync(T entity);
    }
}
