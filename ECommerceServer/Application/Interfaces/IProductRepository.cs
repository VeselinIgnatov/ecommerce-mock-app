using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        public IQueryable<Product> Search(string search);
    }
}
