using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IOrder : IAuditableEntity
    {
        public List<Product> Products { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
