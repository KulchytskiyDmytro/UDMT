using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.CharClass_Subclass;

namespace UDMT.Domain.Configuration;

public class CharClassConfiguration : IEntityTypeConfiguration<CharClass>
{
    public void Configure(EntityTypeBuilder<CharClass> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).IsRequired().HasMaxLength(25);
        builder.Property(c => c.Description).HasMaxLength(2000);
        builder.Property(c => c.IsHomebrew).IsRequired();

        builder.Property(c => c.GrantsSpellcasting).IsRequired();

        builder.Property(c => c.SpellcastingAbility).HasConversion<string>();

        builder.Property(c => c.HpDiceType).HasConversion<string>();

        builder.Property(c => c.ClassCastType).HasConversion<string>();
        
        builder.HasMany(c => c.Subclasses)
            .WithOne(sc => sc.CharClass)
            .HasForeignKey(sc => sc.CharClassId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.SpellcastingProgression)
            .WithOne(sp => sp.CharClass)
            .HasForeignKey(sp => sp.CharClassId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}