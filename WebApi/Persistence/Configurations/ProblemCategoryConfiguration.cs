using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations;
public class ProblemCategoryConfiguration : IEntityTypeConfiguration<ProblemCategory>
{
    public void Configure(EntityTypeBuilder<ProblemCategory> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("ProblemCategory");

        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.Description).HasMaxLength(1500);

        builder.HasOne(d => d.ProblemCatalog)
            .WithMany()
            .HasForeignKey(d => d.ProblemCatalogId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
