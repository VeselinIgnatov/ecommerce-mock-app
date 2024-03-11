using Application.DTOs;
using Application.Interfaces;
using Application.UseCases.Users.Commands;
using Application.UseCases.Users.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
        public UserController(
            IMediator mediator, 
            Serilog.ILogger logger, 
            IAuthenticationService authenticationService)
            : base(mediator, logger)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost(Name = "Register")]
        public async Task<UserDTO> Register(RegisterUserCommand command)
        {
            _logger.Information("Handling command: ", command);

            var user = await _mediator.Send(command);
            var token = _authenticationService.IssueJwtToken(user.Id, user.FirstName, user.LastName, user.IsAdmin);
            _authenticationService.AddToCookies(token);

            return user;
        }

        [HttpPost(Name = "LogIn")]
        public async Task<UserDTO> LogIn(LogInCommand command)
        {
            _logger.Information("Handling command: ", command);
            var user = await _mediator.Send(command);
            var token = _authenticationService.IssueJwtToken(user.Id, user.FirstName, user.LastName, user.IsAdmin);
            _authenticationService.AddToCookies(token);
            return user;
        }

        [HttpGet(Name = "GetUser")]
        public async Task<UserDTO> GetUser(GetUserQuery request)
        {
            _logger.Information("Receiving reqiest: ", request);
            return await _mediator.Send(request);
        }
    }
}
