using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Data
{
    public static class SwaggerImplementation
    {
        /// <summary>
        /// This method does all swagger configuration
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagge(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSwaggerGen(c =>
            {


                c.SwaggerDoc("v0", new OpenApiInfo
                {
                    Title = "Fornecedor API",
                    Description = "Asp.Net Core",
                    Version = "v1.0.1"
               
                });

            });
        }
        /// <summary>
        /// This method does all swagger configuration
        /// </summary>
        /// <param name="app"></param>
        public static void AddSwagger(this IApplicationBuilder app)
        {

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v0/swagger.json", "Fornecedor API");
                c.RoutePrefix = string.Empty;
            });
            app.UseStaticFiles();


        }
    }
}
