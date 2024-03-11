using Application.DTOs;
using Application.Interfaces;
using Application.UseCases.Users.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.Commands
{
    public class AddProductCommandHandler : BaseHandler<Product>, IRequestHandler<AddProductCommand, ProductDTO>
    {
        private readonly IProductRepository _repository;
        public AddProductCommandHandler(
            IMapper mapper,
            IProductRepository repository,
            IMemoryCache cache,
            ILogger logger)
            : base(mapper, logger, cache)
        {
            _repository = repository;
        }

        public async Task<ProductDTO> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Price = request.Price,
                Quantity = request.Quantity,
                BrandId = request.BrandId,
                Categories = _mapper.Map<List<Category>>(request.Categories)
            };

            await _repository.AddAsync(product);

            _cache.Remove("ALL_PRODUCTS");
            
            return _mapper.Map<Product, ProductDTO>(product);
        }
    }
}
