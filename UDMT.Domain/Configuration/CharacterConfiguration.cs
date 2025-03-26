using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Characters;

namespace UDMT.Domain.Configuration;

public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder
            .HasOne(c => c.CharClass)
            .WithMany()
            .HasForeignKey(c => c.CharClassId);
    }
}