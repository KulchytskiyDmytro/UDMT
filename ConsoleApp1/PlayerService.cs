using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

public class PlayerService : IPlayerService
{
    private readonly AppDbContext _context;

    public PlayerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Player>> GetPlayersAsync()
    {
        return await _context.Players
            .Include(r => r.Race)
            .Include(c => c.PlayerClass)
            .ToListAsync();
    }

    public async Task AddNewPlayer(string name, int raceId, int classid)
    {
        var player = new Player
        {
            PlayerName = name,
            RaceId = raceId,
            PlayerClassId = classid
        };
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
    }
}