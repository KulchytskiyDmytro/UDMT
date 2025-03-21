using Microsoft.EntityFrameworkCore;
using NeerCore.Data.EntityFramework.Design;

namespace UDMT.Domain.Context;

public class AppDbContextFactory : DbContextFactoryBase<AppDbContext>
{
    public override string SelectedConnectionName => "Default";
    
    public override string[] SettingsPaths => new[]
    {
        "appsettings.json", // for project
        "../UDMT.Api/appsettings.Local.json" // relative path for migrations
    };
        
    public override AppDbContext CreateDbContext(string[] args) => new(CreateContextOptions());
    
    public override void ConfigureContextOptions(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString,
            options => options.MigrationsAssembly(MigrationsAssembly));
    }
}