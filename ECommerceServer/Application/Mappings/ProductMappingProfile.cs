using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() 
        {
            CreateMap<Product, ProductDTO>().ReverseMap()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));
        }
    }
}
