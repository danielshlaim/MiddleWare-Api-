using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWare_Api_HomeWork
{
    public class StudentsMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string student = context.Request.Path.Value.Split("/")[3];
            await context.Response.WriteAsync($"hello from student {student}\n ");
          
        }
    }
}
