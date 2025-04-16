using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Tech.Mod;

namespace UDMT.Domain.Configuration.Tech.Mod;

public class ModifierConfiguration :  IEntityTypeConfiguration<Modifier>
{
    public void Configure(EntityTypeBuilder<Modifier> builder)
    {
        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
        builder.Property(m=> m.Description).HasMaxLength(2000);
        
    }
}