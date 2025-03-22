﻿using Microsoft.EntityFrameworkCore;
using UDMT.Domain.Entity;

namespace UDMT.Domain.Context;

public class AppDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerClass> PlayerClasses { get; set; }
    
    
    
    public DbSet<Race> Races { get; set; }
    public DbSet<RaceRelation> RaceRelations { get; set; }
    public DbSet<RaceAttributeBonus> RaceAttributeBonusEnumerable { get; set; }
    
    
    
    public DbSet<CharacterAttribute> CharacterAttributes { get; set; }
    
    public DbSet<CharacterSkill> CharacterSkills { get; set; }
    
    public DbSet<Skill> Skills { get; set; }
    
    public DbSet<PlayerClassSavingThrow> PlayerClassSavingThrows { get; set; }


    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}