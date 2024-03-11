using Application.DTOs;
using Application.Interfaces;
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

namespace Application.UseCases.Users.Commands
{
    public class LogInCommandHandler : BaseHandler<User>, IRequestHandler<LogInCommand, UserDTO>
    {
        private readonly IUserRepository _repository;
        public LogInCommandHandler(
            IMapper mapper, 
            IUserRepository repository,
            IMemoryCache cache,
            ILogger logger)
            : base(mapper, logger, cache)
        {
            _repository = repository;
        }

        public async Task<UserDTO> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserAsync(request.Email, request.Password);

            if (user == null) 
            {
                _logger.Debug("Wrong credentials!");
                throw new InvalidCredentialException("Wrong Credentials!");
            }

            return _mapper.Map<User, UserDTO>(user);
        }
    }
}
