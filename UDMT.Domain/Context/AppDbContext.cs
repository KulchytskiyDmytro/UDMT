using Microsoft.EntityFrameworkCore;
using UDMT.Domain.Entity.Characters;
using UDMT.Domain.Entity.Classes;
using UDMT.Domain.Entity.Mechanics;
using UDMT.Domain.Entity.Races;
using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Context;

public class AppDbContext : DbContext
{
    // Characters
    public DbSet<Character> Characters { get; set; }
        
    public DbSet<CharacterAttribute> CharacterAttributes { get; set; }
    
    public DbSet<CharacterSavingThrow> CharacterSavingThrows { get; set; }
    
    public DbSet<CharacterSkill> CharacterSkills { get; set; }
    
    
    // Classes
    public DbSet<CharClass> CharClasses { get; set; }
        
    public DbSet<CharClassSavingThrow> CharClassSavingThrows { get; set; }
    
    public DbSet<CharSubclass> CharSubclasses { get; set; }
    
    public DbSet<ClassMechanic> ClassMechanics { get; set; }
    
    public DbSet<ClassSkill> ClassSkills { get; set; }
        
    public DbSet<Feature> Features { get; set; }
    
    
    // Mechanics
    public DbSet<DamageFormula> DamageFormulas { get; set; }
    
    
    // Races
    public DbSet<Race> Races { get; set; }
        
    public DbSet<RaceAttributeBonus> RaceAttributeBonuses { get; set; }
    
    public DbSet<RaceRelation> RaceRelations { get; set; }
    
    
    // Shared
    public DbSet<Skill> Skills { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}