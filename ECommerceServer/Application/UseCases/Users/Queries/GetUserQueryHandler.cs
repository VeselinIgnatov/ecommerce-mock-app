using Application.DTOs;
using Application.Interfaces;
using Application.UseCases.Products.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace Application.UseCases.Users.Queries
{
    public class GetUserQueryHandler : BaseHandler<Product>, IRequestHandler<GetUserQuery, UserDTO>
    {
        private readonly IUserRepository _repository;
        public GetUserQueryHandler(
            IMapper mapper,
            IUserRepository repository,
            IMemoryCache cache,
            ILogger logger)
            : base(mapper, logger, cache)
        {
            _repository = repository;
        }
        public async Task<UserDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            _logger.Information("Handling request: ", request);

            var products = await _repository.GetUserAsync(request.Email, request.Password);

            if (products == null)
            {
                _logger.Debug("Entity not found in DB");
                throw new EntityNotFoundException();
            }

            return _mapper.Map<UserDTO>(products);
        }
    }
}
