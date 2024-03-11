using Application.Interfaces;
using Domain.Entities;

namespace Application.DTOs
{
    public class ProductDTO: IMapFrom<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double Rating { get; set; }
        public string ImageUrl { get; set; }
        public Guid BrandId { get; set; }
        public BrandDTO Brand { get; set; } = new();
        public List<CategoryDTO> Categories { get; set; } = new();
    }
}
