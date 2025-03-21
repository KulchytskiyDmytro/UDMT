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
    
    // просто блять хз почему но он после введения Атрибутов перестал проводить миграции без этого,
    // и теперь нужно строку подключения прописывать иммено здесь и конструктор,
    // выяснить позже 
    
    public AppDbContext() { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=UDMT;User Id=admin;Password=admin;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
    }
}