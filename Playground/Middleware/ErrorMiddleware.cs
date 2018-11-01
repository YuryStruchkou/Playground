using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Playground.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);
            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                await context.Response.WriteAsync("<h1>404 Not found</h1>");
            }
            else if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                await context.Response.WriteAsync("<h1>403 Forbidden</h1>");
            }
        }
    }
}
