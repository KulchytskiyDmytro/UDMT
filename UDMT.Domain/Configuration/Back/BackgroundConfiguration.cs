using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Back;

namespace UDMT.Domain.Configuration.Back;

public class BackgroundConfiguration : IEntityTypeConfiguration<Background>
{
    public void Configure(EntityTypeBuilder<Background> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(b => b.Name).IsRequired().HasMaxLength(25);
        builder.Property(b => b.Description).HasMaxLength(2000);
        builder.Property(b => b.IsHomebrew).IsRequired();
    }
}