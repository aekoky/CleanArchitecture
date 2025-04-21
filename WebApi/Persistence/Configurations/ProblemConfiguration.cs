using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations;
public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
{
    public void Configure(EntityTypeBuilder<Problem> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("Problem");

        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.Description).HasMaxLength(1500);

        builder.HasOne(d => d.ProblemCategory)
            .WithMany()
            .HasForeignKey(d => d.ProblemCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
