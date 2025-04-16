using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Magic;

namespace UDMT.Domain.Configuration;

public class SpellConfiguration : IEntityTypeConfiguration<Spell>
{
    public void Configure(EntityTypeBuilder<Spell> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Description).HasMaxLength(2000);
        
        builder.Property(s => s.SpellType).HasConversion<string>().IsRequired();
        builder.Property(s => s.SpellSchoolType).HasConversion<string>().IsRequired();
        builder.Property(s => s.CastTimeType).HasConversion<string>();
        builder.Property(s => s.ComponentsType).HasConversion<string>();
        builder.Property(s => s.SpellLevelType).HasConversion<string>();

        builder.Property(s => s.Distance).HasColumnType("int");
        builder.Property(s => s.Duration).HasMaxLength(100);
        builder.Property(s => s.IsRitual).IsRequired();
        builder.Property(s => s.RequiresConcentration).IsRequired();
        
        builder.HasMany(s => s.SpellClasses)
            .WithOne(sc => sc.Spell)
            .HasForeignKey(sc => sc.SpellId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}