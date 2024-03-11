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
    public class SearchProductQueryHandler : BaseHandler<Product>, IRequestHandler<SearchProductQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _repository;
        public SearchProductQueryHandler(
            IMapper mapper,
            IProductRepository repository,
            IMemoryCache cache,
            ILogger logger)
            : base(mapper, logger, cache)
        {
            _repository = repository;
        }

        public async Task<List<ProductDTO>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            _logger.Information("Handling request: ", request);

            var cachedProductDtos = new List<ProductDTO>();

            if(_cache.TryGetValue("ALL_PRODUCTS", out cachedProductDtos))
            {
                return cachedProductDtos.Where(x => x.Name.Contains(request.Search)
                || x.Description.Contains(request.Search)).ToList();
            }

            var products = await _repository.Search(request.Search).ToListAsync();

            if (products == null)
            {
                _logger.Debug("Entity not found in DB");
                throw new EntityNotFoundException();
            }

            return _mapper.Map<List<ProductDTO>>(products);
        }
    }
}
