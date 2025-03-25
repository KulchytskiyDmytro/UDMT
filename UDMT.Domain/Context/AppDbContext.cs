using Microsoft.EntityFrameworkCore;
using UDMT.Domain.Entity;

namespace UDMT.Domain.Context;

public class AppDbContext : DbContext
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharClass> CharClasses { get; set; }
    
    public DbSet<Race> Races { get; set; }
    public DbSet<RaceRelation> RaceRelations { get; set; }
    public DbSet<RaceAttributeBonus> RaceAttributeBonuses { get; set; }

    public DbSet<ClassSkill> ClassSkills { get; set; }
    
    public DbSet<Feature> Features { get; set; }
    
    public DbSet<CharacterSavingThrow> CharacterSavingThrows { get; set; }
    
    public DbSet<CharacterAttribute> CharacterAttributes { get; set; }
    
    public DbSet<CharacterSkill> CharacterSkills { get; set; }
    
    public DbSet<Skill> Skills { get; set; }
    
    public DbSet<CharClassSavingThrow> CharClassSavingThrows { get; set; }


    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}