using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace Application.UseCases.Users.Commands
{
    public class RegisterUserCommandHandler : BaseHandler<User>, IRequestHandler<RegisterUserCommand, UserDTO>
    {
        private readonly IUserRepository _repository;
        public RegisterUserCommandHandler(
            IMapper mapper,
            IUserRepository repository,
            IMemoryCache cache,
            ILogger logger)
            : base(mapper, logger, cache)
        {
            _repository = repository;
        }

        public async Task<UserDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                IsAdmin = request.IsAdmin,
                BillingAddress = request.BillingAddress
            };

            await _repository.AddAsync(user);

            return _mapper.Map<UserDTO>(user);
        }
    }
}
