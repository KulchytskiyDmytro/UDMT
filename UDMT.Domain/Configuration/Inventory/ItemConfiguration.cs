using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Inventory;

namespace UDMT.Domain.Configuration;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(i => i.Id);
        
        builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
        builder.Property(i=> i.Description).HasMaxLength(2000);
        builder.Property(i => i.IsHomebrew).IsRequired();
        builder.Property(i => i.ItemType).HasConversion<string>();
    }
}