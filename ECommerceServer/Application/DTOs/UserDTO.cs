using Application.Interfaces;
using Domain.Entities;

namespace Application.DTOs
{
    public class UserDTO : IMapFrom<User>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
