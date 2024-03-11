using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface ISellableEntity : INamedEntity
    {
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public double Rating { get; set; }

        public string ImageUrl { get; set; }
    }
}
