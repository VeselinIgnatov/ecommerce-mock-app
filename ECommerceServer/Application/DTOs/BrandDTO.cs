using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BrandDTO: IMapFrom<Brand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Category> Categories { get; set; } = new();
        public List<ProductDTO> Products { get; set; } = new();
    }
}
