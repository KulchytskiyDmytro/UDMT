using Spectre.Console;

namespace ConsoleApp1.Services;

public class PlayerConsoleService
{
    private readonly IPlayerService _playerService;
    
    public PlayerConsoleService(IPlayerService playerService)
    {
        _playerService = playerService;
    }
    
    public async Task AddPlayerAsync()
    {
        string name;
        do
        {
            Console.Write("Введите имя игрока: ");
            name = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(name));

        int raceId = GetValidatedNumber("Введите ID расы: ");
        int classId = GetValidatedNumber("Введите ID класса: ");

        await _playerService.AddNewPlayer(name, raceId, classId);
        Console.WriteLine($"Игрок {name} добавлен!");
    }
    
    public async Task ShowPlayersAsync()
    {
        var players = await _playerService.GetPlayersAsync();
        if (!players.Any())
        {
            Console.WriteLine("Еще нет игроков.");
            return;
        }

        var table = new Table().Border(TableBorder.Double);
        table.AddColumn("Номер");
        table.AddColumn("Имя");
        table.AddColumn("Класс");
        table.AddColumn("Раса");
        table.ShowRowSeparators();

        foreach (var player in players)
        {
            table.AddRow(
                player.Id.ToString(), 
                player.PlayerName, 
                player.PlayerClass.PlayerClassName, 
                player.Race.Race_Name);
        }

        AnsiConsole.Write(new Panel(table).Header("[blue]== Список Игроков ==[/]", Justify.Center).NoBorder());
    }
    
    public async Task RemovePlayerAsync()
    {
        Console.Write("Введите id игрока: ");
        int id = Convert.ToInt32(Console.ReadLine());
        await _playerService.DeletePlayerAsync(id);
    }
    
    private static int GetValidatedNumber(string message)
    {
        int number;
        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out number));

        return number;
    }
}