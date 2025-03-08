using ConsoleApp1;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Rendering;

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
                  Console.WriteLine("3. Удалить игрока");
                  Console.WriteLine("4. Выход");
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
                              await RemovePlayer(playerService);
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
            var players = await playerService.GetPlayersAsync();
            if (players.Any())
            {
                  static IRenderable CreateTable(string name, TableBorder border, List<Player> players)
                  {
                        var table = new Table().Border(border);
                        table.ShowRowSeparators();
                        table.AddColumn("Номер");
                        table.AddColumn("Имя");
                        table.AddColumn("Класс");
                        table.AddColumn("Расса");
                        foreach (var player in players)
                        {
                              table.AddRow($"{player.Id}", $"{player.PlayerName}", $"{player.PlayerClass.PlayerClassName}", $"{player.Race.Race_Name}" );
                        }

                        return new Panel(table)
                              .Header($" [blue]{name}[/] ", Justify.Center)
                              .NoBorder();
                  }

                  var items = new[]
                  {
                        CreateTable("==Список Игроков==", TableBorder.Double, players),
                  };
                  
                  AnsiConsole.Write(new Columns(items).Collapse());
            }
            else
            {
                  Console.WriteLine("Еще нет игроков.");
            }
      }
      static async Task RemovePlayer(IPlayerService playerService)
      {
            Console.Write("Введите id игрока: ");
            int id = Convert.ToInt32(Console.ReadLine());
            await playerService.DeletePlayer(id);
      }
}