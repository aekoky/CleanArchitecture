using CleanArchitecture.Persistence.Initialization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);
if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("NSwag")))
{
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Logging.AddDebug();
}
// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebApiServices(builder.Configuration);
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();
app.UseForwardedHeaders();
//app.UsePathBase("/api");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    IdentityModelEventSource.ShowPII = true;
    app.UseMigrationsEndPoint();
}


// Initialise and seed database
using var scope = app.Services.CreateScope();
if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("NSwag")))
{
    var initialiserMultiTenant = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
    await initialiserMultiTenant.InitialiseAsync();
    await initialiserMultiTenant.SeedAsync();
}

app.UseHealthChecks("/health");
app.UseStaticFiles();


app.UseOpenApi();
app.UseSwaggerUi(settings =>
{
    settings.Path = "/docs";
    settings.DocumentPath = "/docs/specification.json";
});


app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
    app.UseCors("DevelopmentCors");
else
    app.UseCors("ProductionCors");


app.MapControllers();

app.Run();