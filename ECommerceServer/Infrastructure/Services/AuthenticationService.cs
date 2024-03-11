using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthenticationService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = httpContextAccessor;
        }


        public string IssueJwtToken(Guid id, string firstName, string lastName, bool isAdmin)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", id.ToString()),
                new Claim("Name", $"{firstName} {lastName}"),
                new Claim("Admin", isAdmin.ToString())
            };
            var securityKey = _configuration.GetSection("SecurityToken").Value!;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public void AddToCookies(string token)
        {
            _contextAccessor.HttpContext?.Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true
            });
        }

        public bool ValidateUser()
        {
            throw new NotImplementedException();
        }
    }
}
