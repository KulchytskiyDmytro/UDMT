using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.CharClass_Subclass;

namespace UDMT.Domain.Configuration;

public class CharSubclassConfiguration : IEntityTypeConfiguration<CharSubclass>
{
    public void Configure(EntityTypeBuilder<CharSubclass> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(cs => cs.Name).IsRequired().HasMaxLength(25);
        builder.Property(cs => cs.Description).HasMaxLength(2000);
        builder.Property(cs => cs.IsHomebrew).IsRequired();

        builder.Property(cs => cs.GrantsSpellcasting).IsRequired();

        builder.Property(cs => cs.CastTypeOverride).HasConversion<string>();
    }
}