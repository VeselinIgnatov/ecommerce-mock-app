using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Users.Commands
{
    public class RegisterUserCommand : IRequest<UserDTO>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BillingAddress { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
