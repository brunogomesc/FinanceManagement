using Application.Abstractions.Ports.Repositories;
using Infrastructure.Postgres.Databases;
using Infrastructure.Postgres.Databases.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Postgres
{
    public static class InfrastructurePostgresLayerDependency
    {

        public static IServiceCollection AddPostgresLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext
            services.AddDbContext<FinanceManagementContext>((provider, builder) =>
            {
                builder
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging()
                    .UseNpgsql(configuration.GetConnectionString("FinanceManagementDb"), options =>
                    {
                        options.MigrationsAssembly(typeof(FinanceManagementContext).Assembly.GetName().Name);
                        options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
            });

            // Register Repositories
            services.AddScoped<IFinanceManagementRepository, FinanceManagementRepository>();

            return services;
        }

    }
}
