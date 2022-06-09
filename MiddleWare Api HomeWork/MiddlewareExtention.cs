using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWare_Api_HomeWork
{
    public static class MiddlewareExtention 
    {
        public static IApplicationBuilder PrintMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ClassesMiddleWare>();
        }
    }
}
