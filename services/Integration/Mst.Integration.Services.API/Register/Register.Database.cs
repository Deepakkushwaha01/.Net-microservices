using External.API.Settings;
using Integration.Core.Persistence.Common.Sql.Context;
using Microsoft.EntityFrameworkCore;
using Mst.Core.Persistence.Common.Sql.Context;
using Mst.Core.Queries.Infrastructure.Context;

namespace External.API.Registers
{
    public static partial class Register
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            ConnectionStringsSettings connectionStringsSettings = new(configuration);
            services.RegisterIntegrationDb(connectionStringsSettings);
            services.RegisterReadonlyIntegrationDb(connectionStringsSettings);

            return services;
        }

        private static IServiceCollection RegisterIntegrationDb(this IServiceCollection services, ConnectionStringsSettings settings)
        {
            services.AddScoped<IIntegrationDbContext, IntegrationDbContext>().AddDbContext<IntegrationDbContext>(options =>
                    {
                        options.UseSqlServer(settings.IntegrationSqlDb,
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(15),
                            errorNumbersToAdd: null);
                        });
                    });
            return services;
        }

        private static IServiceCollection RegisterReadonlyIntegrationDb(this IServiceCollection services, ConnectionStringsSettings settings)
        {
            services.AddScoped<IReadonlyIntegrationDbContext, ReadonlyIntegrationDbContext>().AddDbContext<ReadonlyIntegrationDbContext>(options =>
                    {
                        options.UseSqlServer(settings.IntegrationSqlDb,
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(15),
                            errorNumbersToAdd: null);
                        });
                    });
            return services;
        }

        public static IApplicationBuilder UseDatabaseHealthCheck(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IntegrationDbContext>();
                dbContext.HealthCheck();
            }
            return app;
        }
    }
}