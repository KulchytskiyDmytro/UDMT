using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

class Program
{
      static async Task Main()
      {

            var services = new ServiceCollection();
            
            services.AddDbContext<AppDbContext>(options =>
                  options.UseSqlServer("Data Source=localhost;Initial Catalog=UDMT;User Id=admin;Password=admin;MultipleActiveResultSets=true;TrustServerCertificate=True"));

            services.AddScoped<IPlayerService, PlayerService>();

            var serviceProvider  = services.BuildServiceProvider();
            
            var playerService = serviceProvider.GetRequiredService<IPlayerService>();
            
            while (true)
            {
                  Console.Clear();
                  Console.WriteLine("=== Меню ===");
                  Console.WriteLine("1. Добавить игрока");
                  Console.WriteLine("2. Показать всех игроков");
                  Console.WriteLine("3. Выход");
                  Console.Write("Выберите действие: ");

                  string choice = Console.ReadLine();

                  switch (choice)
                  {
                        case "1":
                              await AddPlayer(playerService);
                              break;
                        case "2":
                              await ShowPlayers(playerService);
                              break;
                        case "3":
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
      static async Task AddPlayer(IPlayerService playerService)
      {
            Console.Write("Введите имя игрока: ");
            string name = Console.ReadLine();
            while (name == "")
            {
                  Console.WriteLine("Пожалуйства введите имя игрока: ");
                  name = Console.ReadLine();
            }

            Console.Write("Введите ID расы: ");
            if (!int.TryParse(Console.ReadLine(), out int raceId))
            {
                  Console.WriteLine("Ошибка: некорректный ввод ID расы.");
                  return;
            }

            Console.Write("Введите ID класса: ");
            if (!int.TryParse(Console.ReadLine(), out int classId))
            {
                  Console.WriteLine("Ошибка: некорректный ввод ID класса.");
                  return;
            }

            await playerService.AddNewPlayer(name, raceId, classId);
            Console.WriteLine($"Игрок {name} добавлен!");
      }
      static async Task ShowPlayers(IPlayerService playerService)
      {
            Console.WriteLine("Список игроков: ");
            var players = await playerService.GetPlayersAsync();
            if (players.Any())
            {
                  foreach (var player in players)
                  {
                        Console.WriteLine($"ID: {player.Id}, Имя: {player.PlayerName}, Класс: {player.PlayerClass.PlayerClassName}, Расса: {player.Race.Race_Name}");
                  }
            }
            else
            {
                  Console.WriteLine("Еще нет игроков.");
            }
      }
}
