using Application.Services;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Server
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {

            services.AddScoped<IOfficeService, OfficeService>();
                      
            services.AddHttpContextAccessor();



            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AutoPiter API",
                    Description = "Тестовое задание",
                    Contact = new OpenApiContact
                    {
                        Name = "Новиков Андрей",
                        Url = new Uri("https://t.me/AndrewBPC"),
                        Email = "a.novikov05@yandex.ru",
                    }
                });
                
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Server.xml");
                options.IncludeXmlComments(filePath);
                //options.MapType<ConnectionType>(() => new OpenApiSchema() { Enum = new List<int>(){1,2});
            });
            return services;
        }
    }
}
