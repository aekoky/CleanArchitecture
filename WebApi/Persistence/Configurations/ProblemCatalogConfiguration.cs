using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations;
public class ProblemCatalogConfiguration : IEntityTypeConfiguration<ProblemCatalog>
{
    public void Configure(EntityTypeBuilder<ProblemCatalog> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("ProblemCatalog");

        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.Description).HasMaxLength(1500);
    }
}
