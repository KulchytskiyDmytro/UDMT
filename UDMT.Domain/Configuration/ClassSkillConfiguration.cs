using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity;

namespace UDMT.Domain.Configuration;

public class ClassSkillConfiguration: IEntityTypeConfiguration<ClassSkill>
{
    public void Configure(EntityTypeBuilder<ClassSkill> builder)
    {
        builder.HasKey(cs => cs.Id);
        
        builder.HasOne(cs => cs.CharClass)
            .WithMany(cc => cc.ClassSkills)
            .HasForeignKey(cs => cs.CharClassId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        builder.HasOne(cs => cs.Skill)
            .WithMany(s => s.ClassSkills)
            .HasForeignKey(cs => cs.SkillId)
            .OnDelete(DeleteBehavior.Restrict); 
        
        builder.HasIndex(cs => new { cs.CharClassId, cs.SkillId })
            .IsUnique();
    }
}