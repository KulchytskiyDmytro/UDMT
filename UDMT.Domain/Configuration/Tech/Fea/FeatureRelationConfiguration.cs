using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Tech.Fea;

namespace UDMT.Domain.Configuration.Tech.Fea;

public class FeatureRelationConfiguration :  IEntityTypeConfiguration<FeatureRelation>
{
    public void Configure(EntityTypeBuilder<FeatureRelation> builder)
    {
        builder.HasOne(fr => fr.Feature)
            .WithMany() 
            .HasForeignKey(fr => fr.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}