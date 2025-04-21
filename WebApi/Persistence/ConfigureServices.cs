using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Persistence.Interceptors;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Persistence.Initialization;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("NSwag")))? configuration.GetConnectionString("DefaultConnection") : configuration.GetConnectionString("DesignTimeConnection");
        services.AddScoped<ISaveChangesInterceptor, AuditableEntitySaveChangesInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlServer(connectionString);
        });
        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}
