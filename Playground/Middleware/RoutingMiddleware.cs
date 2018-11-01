using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Playground.Middleware
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var route = context.Request.Path.Value.ToLower();
            if (route == "/home")
            {
                await context.Response.WriteAsync("<h1>Home page</h1>");
            }
            else if (route == "/about")
            {
                await context.Response.WriteAsync("<h1>About</h1>");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }
    }
}
