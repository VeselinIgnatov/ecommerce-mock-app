using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IProduct : ISellableEntity
    {
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<Category> Categories { get; set; }
        public List<Order > Orders { get; set; }
    }
}
