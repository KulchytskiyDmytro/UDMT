using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UDMT.Domain.Context;

namespace UDMT.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseWithUserIdentity();
        return services;
    } 
    
    // Запил на авторизацю
    private static void AddDatabaseWithUserIdentity(this IServiceCollection services)
    {
        var contextFactory = new AppDbContextFactory();
        services.AddDbContext<AppDbContext>(cob => contextFactory.ConfigureContextOptions(cob));

        services.AddScoped<AppDbContextFactory>();
    }
}