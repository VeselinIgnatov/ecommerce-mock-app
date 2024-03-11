using Domain.Entities;

namespace Domain
{
    public interface IBrand : INamedEntity
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
