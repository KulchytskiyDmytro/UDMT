using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Races;

namespace UDMT.Domain.Configuration;

public class RaceRelationConfiguration : IEntityTypeConfiguration<RaceRelation>
{
    public void Configure(EntityTypeBuilder<RaceRelation> builder)
    {
        builder.ToTable("RaceRelations");
        
        builder.HasKey(r => r.Id);
        
        builder.HasIndex(r => new { r.RaceId, r.SubraceId }).IsUnique();
        
        builder
            .HasOne(r => r.Race)
            .WithMany(race => race.RaceRelations)
            .HasForeignKey(r => r.RaceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(r => r.Subrace)
            .WithMany()
            .HasForeignKey(r => r.SubraceId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
    }
}