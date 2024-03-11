using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : IProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid AddeddBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public double Rating { get; set; }
        public string ImageUrl { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
        public List<Order> Orders { get; set; }
    }
}
