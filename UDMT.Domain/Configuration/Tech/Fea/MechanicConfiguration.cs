using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Tech.Fea;

namespace UDMT.Domain.Configuration.Tech.Fea;

public class MechanicConfiguration :  IEntityTypeConfiguration<Mechanic>
{
    public void Configure(EntityTypeBuilder<Mechanic> builder)
    {
        builder.HasOne(m => m.Feature)
            .WithOne(f => f.Mechanic)
            .HasForeignKey<Mechanic>(m => m.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}