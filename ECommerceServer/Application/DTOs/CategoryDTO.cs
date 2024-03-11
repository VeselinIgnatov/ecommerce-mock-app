using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CategoryDTO : IMapFrom<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<ProductDTO> Products { get; set; } = new();
        public List<BrandDTO> Brands { get; set; } = new();
    }
}
