using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

public class PlayerService : IPlayerService
{
    private readonly AppDbContext _context;
    private IPlayerService _playerServiceImplementation;

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

    public async Task DeletePlayerAsync(int playerId)
    {
        var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == playerId);
        if (player != null) _context.Players.Remove(player);
        await _context.SaveChangesAsync();
    }

}