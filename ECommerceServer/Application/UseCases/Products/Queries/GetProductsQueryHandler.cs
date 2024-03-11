using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace Application.UseCases.Products.Queries
{
    public class GetProductsQueryHandler : BaseHandler<Product>, IRequestHandler<GetProductsQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _repository;
        public GetProductsQueryHandler(
            IMapper mapper,
            IProductRepository repository,
            IMemoryCache cache,
            ILogger logger)
            : base(mapper, logger, cache)
        {
            _repository = repository;
        }

        public async Task<List<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            _logger.Information("Handling request: ", request);

            var productDtos = new List<ProductDTO>();

            if (_cache.TryGetValue("ALL_PRODUCTS", out productDtos))
            {
                return productDtos;
            }

            _logger.Information($"Collection not found in cache.");


            var products = await _repository
                                .GetAll()
                                .Include(x => x.Brand)
                                .Include(x => x.Categories)
                                .ToListAsync();

            if (!products.Any())
            {
                _logger.Debug("No data returned from DB");
                throw new EntityNotFoundException("No data returned from DB");
            }

            productDtos = _mapper.Map<List<Product>, List<ProductDTO>>(products);

            _cache.Set("ALL_PRODUCTS", productDtos, new DateTimeOffset(DateTime.Now.AddMinutes(60)));

            return productDtos;
        }
    }
}