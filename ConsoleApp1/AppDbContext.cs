using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

public class AppDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerClass> PlayerClasses { get; set; }
    public DbSet<Race> Races { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}