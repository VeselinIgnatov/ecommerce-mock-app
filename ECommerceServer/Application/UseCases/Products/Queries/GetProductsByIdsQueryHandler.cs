using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace Application.UseCases.Products.Queries
{
    public class GetProductsByIdsQueryHandler 
        : BaseHandler<Product>, IRequestHandler<GetProductsByIdsQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _repository;
        public GetProductsByIdsQueryHandler(
            IMapper mapper,
            IProductRepository repository,
            IMemoryCache cache,
            ILogger logger)
            : base(mapper, logger, cache)
        {
            _repository = repository;
        }

        public async Task<List<ProductDTO>> Handle(GetProductsByIdsQuery request, CancellationToken cancellationToken)
        {
            _logger.Information("Handling request: ", request);

            var products = new List<Product>();
            var productDtos = new List<ProductDTO>();

            if (_cache.TryGetValue("ALL_PRODUCTS", out productDtos))
            {
                var cachedProducts = productDtos.Where(x => request.Ids.Contains(x.Id)).ToList();

                if (cachedProducts != null) return cachedProducts;

                _logger.Information($"Entity not found in cache. Ids: {string.Join(',', request.Ids)}");
            }

            products = await _repository.GetByIdsAsync(request.Ids);

            if (products == null)
            {
                _logger.Debug("Entity not found in DB");
                throw new EntityNotFoundException();
            }

            return _mapper.Map<List<ProductDTO>>(products);
        }
    }
}
