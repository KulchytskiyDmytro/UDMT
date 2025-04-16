using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity;
using UDMT.Domain.Entity.Char;

namespace UDMT.Domain.Configuration;

public class FeatConfiguration : IEntityTypeConfiguration<Feat>
{
    public void Configure(EntityTypeBuilder<Feat> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Name).IsRequired().HasMaxLength(50);
        builder.Property(f => f.Description).HasMaxLength(2000);
    }
}