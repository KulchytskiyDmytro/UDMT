using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Race_Subrace;

namespace UDMT.Domain.Configuration;

public class SubraceConfiguration : IEntityTypeConfiguration<SubRace>
{
    public void Configure(EntityTypeBuilder<SubRace> builder)
    {
        builder.HasKey(sr => sr.Id);

        builder.Property(sr => sr.Name).IsRequired().HasMaxLength(25);
        builder.Property(sr => sr.Description).HasMaxLength(2000);
        builder.Property(sr => sr.IsHomebrew).IsRequired();
    }
}