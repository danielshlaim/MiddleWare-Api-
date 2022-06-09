using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWare_Api_HomeWork
{
    public class ClassesMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string studentclass = context.Request.Path.Value.Split("/")[2];

            await context.Response.WriteAsync($"hello from class {studentclass}\n");
            await next(context);

        }
    }
}
