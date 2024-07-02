using CodeBase.Infrastructure.AppDbContext;
using CodeBase.Infrastructure.Interceptors;
using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CodeBase.Infrastructure.ConfigureServices.Database
{
    public static class ConfigureDbService
    {
        public static void AddDbService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<AuditableInterceptor>();
            services.AddSingleton<SoftDeleteInterceptor>();

            services.AddDbContext<CodebaseDbContext>((serviceProvider, builderOption) =>
            {
                var dbOptions = serviceProvider.GetService<IOptions<DbOptions>>()!.Value;

                builderOption.UseNpgsql(dbOptions.ConnectionString,
                    sqlServerAction =>
                    {
                        sqlServerAction.EnableRetryOnFailure(dbOptions.MaxRetryCount);
                        sqlServerAction.CommandTimeout(dbOptions.CommandTimeout);
                    })
                .AddInterceptors(
                    serviceProvider.GetService<AuditableInterceptor>()!,
                    serviceProvider.GetService<SoftDeleteInterceptor>()!)
                .UseExceptionProcessor();

                builderOption.EnableDetailedErrors(dbOptions.EnableDetailedErrors);
                builderOption.EnableSensitiveDataLogging(dbOptions.EnableSensitiveDataLogging);
            });
        }
    }
}

