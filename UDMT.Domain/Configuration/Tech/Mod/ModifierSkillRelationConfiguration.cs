using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Tech.Mod;

namespace UDMT.Domain.Configuration.Tech.Mod;

public class ModifierSkillRelationConfiguration :  IEntityTypeConfiguration<ModifierSkillRelation>
{
    public void Configure(EntityTypeBuilder<ModifierSkillRelation> builder)
    {
        builder.HasOne(msr => msr.Modifier)
            .WithMany() 
            .HasForeignKey(msr => msr.ModifierId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}