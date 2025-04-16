using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Race_Subrace;

namespace UDMT.Domain.Configuration;

public class RaceConfiguration : IEntityTypeConfiguration<Race>
{
    public void Configure(EntityTypeBuilder<Race> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Name).IsRequired().HasMaxLength(25);
        builder.Property(r => r.Description).HasMaxLength(2000);
        builder.Property(r => r.IsHomebrew).IsRequired();
        
        builder.HasMany(r => r.SubRaces)
            .WithOne(sr => sr.Race)
            .HasForeignKey(sr => sr.RaceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}