using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Tech.Mod;

namespace UDMT.Domain.Configuration.Tech.Mod;

public class ModifierRelationConfiguration :  IEntityTypeConfiguration<ModifierRelation>
{
    public void Configure(EntityTypeBuilder<ModifierRelation> builder)
    {
        builder.HasOne(msr => msr.Modifier)
            .WithMany() 
            .HasForeignKey(msr => msr.ModifierId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}