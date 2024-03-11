using Application.DTOs;
using MediatR;

namespace Application.UseCases.Users.Commands
{
    public class LogInCommand : IRequest<UserDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
