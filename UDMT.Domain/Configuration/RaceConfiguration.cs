using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity;

namespace UDMT.Domain.Configuration;

public class RaceConfiguration : IEntityTypeConfiguration<Race>
{
    public void Configure(EntityTypeBuilder<Race> builder)
    {
        builder
            .HasMany(r => r.AttributeBonuses)
            .WithOne(b => b.Race)
            .HasForeignKey(b => b.RaceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(r => r.RaceRelations)
            .WithOne(rr => rr.Race)
            .HasForeignKey(rr => rr.RaceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}