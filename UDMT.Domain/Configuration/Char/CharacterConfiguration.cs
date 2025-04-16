using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Char;

namespace UDMT.Domain.Configuration;

public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name).IsRequired().HasMaxLength(25);
        builder.Property(c => c.PlayerName).HasMaxLength(25);
        builder.Property(c => c.Alignment).HasMaxLength(25);
        builder.Property(c => c.Gender).HasMaxLength(25);
        builder.Property(c => c.Deity).HasMaxLength(25);
        builder.Property(c => c.Backstory).HasMaxLength(5000);

        builder.HasOne(c => c.Race)
            .WithMany()
            .HasForeignKey(c => c.RaceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Background)
            .WithMany()
            .HasForeignKey(c => c.BackgroundId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.ClassLevels)
            .WithOne(cl => cl.Character)
            .HasForeignKey(cl => cl.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Attributes)
            .WithOne(a => a.Character)
            .HasForeignKey(a => a.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.SavingThrows)
            .WithOne(s => s.Character)
            .HasForeignKey(s => s.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Skills)
            .WithOne(s => s.Character)
            .HasForeignKey(s => s.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Spells)
            .WithOne(s => s.Character)
            .HasForeignKey(s => s.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Inventory)
            .WithOne(i => i.Character)
            .HasForeignKey(i => i.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Currency)
            .WithOne(cur => cur.Character)
            .HasForeignKey(cur => cur.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}