using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;
using System.Reflection;

namespace CleanArchitecture.Persistence.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<Problem> Problems => Set<Problem>();

    public DbSet<ProblemCatalog> ProblemCatalogs => Set<ProblemCatalog>();

    public DbSet<ProblemCategory> ProblemCategories => Set<ProblemCategory>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await Database.BeginTransactionAsync(cancellationToken);
    }
}

//add-migration Initial -outputdir Migrations/Application -context ApplicationDbContext
//add-migration version-1 -outputdir Migrations/Application -context ApplicationDbContext
//add-migration Initial -outputdir Migrations/MultiTenant -context MultiTenantStoreDbContext
//script-migration -context ApplicationDbContext
//remove-migration -context ApplicationDbContext
//update-database -context ApplicationDbContext