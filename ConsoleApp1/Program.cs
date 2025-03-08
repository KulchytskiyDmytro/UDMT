using ConsoleApp1;
using ConsoleApp1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

class Program
{
      static async Task Main()
      {
            await using var serviceProvider = ConfigureServices();
            
            var playerConsoleService = serviceProvider.GetRequiredService<PlayerConsoleService>();
            
            while (true)
            {
                  Console.Clear();
                  Console.WriteLine("=== Меню ===");
                  Console.WriteLine("1. Добавить игрока");
                  Console.WriteLine("2. Показать всех игроков");
                  Console.WriteLine("3. Удалить игрока");
                  Console.WriteLine("4. Выход");
                  Console.Write("Выберите действие: ");

                  string? choice = Console.ReadLine();

                  switch (choice)
                  {
                        case "1":
                              await playerConsoleService.AddPlayerAsync();
                              break;
                        case "2":
                              await playerConsoleService.ShowPlayersAsync();
                              break;
                        case "3":
                              await playerConsoleService.RemovePlayerAsync();
                              break;
                        case "4":
                              Console.WriteLine("Выход...");
                              return;
                        default:
                              Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                              break;
                  }

                  Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                  Console.ReadKey();
            }
      }

      static ServiceProvider ConfigureServices()
      {
            var services = new ServiceCollection();
            
            services.AddDbContext<AppDbContext>(options =>
                  options.UseSqlServer("Data Source=localhost;Initial Catalog=UDMT;User Id=admin;Password=admin;MultipleActiveResultSets=true;TrustServerCertificate=True"));
            
            services.AddScoped<IPlayerService, PlayerService>();

            services.AddScoped<PlayerConsoleService>();

            return services.BuildServiceProvider();
      }
}