using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private IHttpContextAccessor _contextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        public Guid UserId => Guid.Parse(_contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}
