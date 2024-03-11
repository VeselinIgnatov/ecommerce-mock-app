using Domain.Entities;

namespace Domain
{
    public interface ICategory : INamedEntity
    {
        public List<Brand> Brands { get; set; }
        public List<Product> Products { get; set; }
    }
}
