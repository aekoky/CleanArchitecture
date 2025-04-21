using NSwag.Generation.Processors.Security;
using System.Text.Json.Serialization;
using ZymLabs.NSwag.FluentValidation;
using Microsoft.AspNetCore.Mvc;
using YamlDotNet.Serialization;
using NSwag;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddHttpContextAccessor();

        services.AddHealthChecks();

        services.AddControllers()
        .AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())).AddNewtonsoftJson(setup =>
        {
            setup.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            setup.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            setup.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
        });

        services.AddSignalR(options => options.MaximumParallelInvocationsPerClient = 10);

        services.AddScoped<FluentValidationSchemaProcessor>(provider =>
        {
            var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
            var loggerFactory = provider.GetService<ILoggerFactory>();

            return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
        });

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddOpenApiDocument((configure, serviceProvider) =>
        {
            var fluentValidationSchemaProcessor = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<FluentValidationSchemaProcessor>();

            // Add the fluent validations schema processor
            configure.SchemaSettings.SchemaProcessors.Add(fluentValidationSchemaProcessor);
            configure.Title = "CleanArchitecture API";
            configure.PostProcess = (document) => document.BasePath = "/api";
        });
        services.AddCors(cors =>
        {
            cors.AddPolicy("ProductionCors", builder => builder.WithOrigins(["http://localhost"]).AllowAnyMethod().AllowAnyHeader());
            cors.AddPolicy("DevelopmentCors", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });
        return services;
    }
}
