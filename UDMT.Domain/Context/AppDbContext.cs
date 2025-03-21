using Microsoft.EntityFrameworkCore;
using UDMT.Domain.Entity;

namespace UDMT.Domain.Context;

public class AppDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerClass> PlayerClasses { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<CharacterAttribute> CharacterAttributes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public AppDbContext() { }
    
}