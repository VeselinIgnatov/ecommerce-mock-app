using System.Security.Claims;
using System.Text;

namespace Web.Middlewares
{

    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Cookies["jwt"];

            if (authHeader != null)
            {
                int startPoint = authHeader.IndexOf(".") + 1;
                int endPoint = authHeader.LastIndexOf(".");

                var tokenString = authHeader
                    .Substring(startPoint, endPoint - startPoint).Split(".");
                var token = tokenString[0].ToString();
                int length = token.Length + (4 - (token.Length % 4));
                token = token.PadRight(length, '=');

                var credentialString = Encoding.UTF8
                    .GetString(Convert.FromBase64String(token));

                var credentials = credentialString.Split(new char[] { ':', ',' });

                var id = credentials[1].Replace("\"", "");
                var userName = credentials[3].Replace("\"", "");
                var admin = credentials[5].Replace("\"", "");

                var claims = new[]
                {
                       new Claim("Id", id),
                       new Claim("name", userName),
                       new Claim("admin", admin),
                    };
                var identity = new ClaimsIdentity(claims, "basic");
                context.User = new ClaimsPrincipal(identity);

            }
            //Pass to the next middleware
            await _next(context);
        }
    }
}
