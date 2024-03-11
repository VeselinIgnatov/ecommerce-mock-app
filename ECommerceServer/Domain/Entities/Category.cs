using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : ICategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid AddeddBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public List<Product> Products { get; set; } = new ();
        public List<Brand> Brands { get; set; } = new ();
    }
}
