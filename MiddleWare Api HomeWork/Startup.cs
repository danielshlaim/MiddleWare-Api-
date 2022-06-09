using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddleWare_Api_HomeWork
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MiddleWare_Api_HomeWork", Version = "v1" });
            });
            services.AddTransient<ClassesMiddleWare>();
            services.AddTransient<StudentsMiddleWare>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.Map("/students",HandleStudentInfo);

            //app.UseMiddleware<ClassesMiddleWare>();
            //app.UseMiddleware<StudentsMiddleWare>();


            app.PrintMiddleware();

            app.Map("/class5",ChangeLocation);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiddleWare_Api_HomeWork v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
        private void HandleStudentInfo(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                string studentclass = context.Request.Path.Value.Split("/")[1];

                await context.Response.WriteAsync($"hello from class {studentclass}\n");
                await next();
            });

            app.Use(async (context, next) =>
            {
                string student = context.Request.Path.Value.Split("/")[2];
                await context.Response.WriteAsync($"hello from student {student}\n ");

            });
        }

       private void ChangeLocation(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("change location of class 5");
            });
        }

        
    }
}
