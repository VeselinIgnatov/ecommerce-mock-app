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
    public class GetProductByIdQueryHandler : BaseHandler<Product>, IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly IProductRepository _repository;
        public GetProductByIdQueryHandler(
            IMapper mapper,
            IProductRepository repository,
            IMemoryCache cache,
            ILogger logger)
            : base(mapper, logger, cache)
        {
            _repository = repository;
        }

        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.Information("Handling request: ", request);

            var product = new Product();
            var productDtos = new List<ProductDTO>();

            if (_cache.TryGetValue("ALL_PRODUCTS", out productDtos))
            {
                var cachedProduct = productDtos.FirstOrDefault(x => x.Id == request.Id);

                if (cachedProduct != null) return cachedProduct;

                _logger.Information($"Entity not found in cache. Id: {request.Id}");
            }

             product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
            {
                _logger.Debug("Entity not found in DB");
                throw new EntityNotFoundException();
            }

            return _mapper.Map<ProductDTO>(product);
        }
    }
}
