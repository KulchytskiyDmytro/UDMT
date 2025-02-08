using ConsoleApp1.Models;

namespace ConsoleApp1;

public interface IPlayerService
{
    Task<List<Player>> GetPlayersAsync();
    Task AddNewPlayer(string name, int race, int classname);
}