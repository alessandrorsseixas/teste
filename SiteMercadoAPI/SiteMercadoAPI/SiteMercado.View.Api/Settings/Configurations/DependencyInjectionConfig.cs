using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SiteMercado.Domain.SeedWorks.Classes;
using SiteMercado.Domain.SeedWorks.Interfaces.Repositories;
using SiteMercado.Domain.SeedWorks.Interfaces.Services;
using SiteMercado.Infrastructure.Context;
using SiteMercado.Infrastructure.Repositories;
using SiteMercado.Service.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMercado.View.Api.Settings.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {


            services.AddScoped<AppDbContext>();


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificator, Notificator>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();



            return services;
        }
    }
}
