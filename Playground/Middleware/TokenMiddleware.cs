using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Playground.Middleware
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly string _token;

        public TokenMiddleware(RequestDelegate next, string token)
        {
            _next = next;
            _token = token;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token == _token)
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
            }
        }
    }
}
