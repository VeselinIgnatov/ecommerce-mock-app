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
    public class GetProductsSliceQueryHandler : BaseHandler<Product>, IRequestHandler<GetProductsSliceQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _repository;
        public GetProductsSliceQueryHandler(
            IMapper mapper,
            IProductRepository repository,
            IMemoryCache cache,
            ILogger logger)
            : base(mapper, logger, cache)
        {
            _repository = repository;
        }

        public async Task<List<ProductDTO>> Handle(GetProductsSliceQuery request, CancellationToken cancellationToken)
        {
            _logger.Information("Handling request: ", request);

            var products = await _repository
                                .GetSlice(request.Skip, request.Take)
                                .Include(x => x.Brand)
                                .Include(x => x.Categories)
                                .ToListAsync();

            if (!products.Any())
            {
                _logger.Debug("No data returned from DB");
                throw new EntityNotFoundException("No data returned from DB");
            }

            return _mapper.Map<List<Product>, List<ProductDTO>>(products);
        }
    }
}
