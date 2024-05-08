using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<ApplicationDbContext>((options) =>
            {

                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure"));
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();

            });

            services.AddScoped<ApplicationDbContext>();

            services.AddScoped<ApplicationDbContextInitialiser>();


            return services;
        }

    }
}
