using Microsoft.EntityFrameworkCore;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;

namespace UDMT.Application.Services;

public class PlayerService : IPlayerService
{
    private readonly AppDbContext _context;
    private IPlayerService _playerServiceImplementation;

    public PlayerService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task AddNewPlayer(PlayerDto playerDto)
    {
        var player = new Player
        {
            PlayerName = playerDto.PlayerName,
            RaceId = playerDto.RaceId,
            PlayerClassId = playerDto.PlayerClassId
        };
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Player>> GetPlayersAsync()
    {
        return await _context.Players
            .Include(r => r.Race)
            .Include(c => c.PlayerClass)
            .ToListAsync();
    }

    public async Task UpdatePlayerAsync(PlayerDto playerDto)
    {
        var player = await _context.Players
            .FirstOrDefaultAsync(p => p.Id == playerDto.Id);

        if (player == null) throw new Exception($"Player Id={playerDto.Id} не найден");
        
        player.PlayerName = playerDto.PlayerName;
        player.RaceId = playerDto.RaceId;
        player.PlayerClassId = playerDto.PlayerClassId;

        await _context.SaveChangesAsync();
    }

    public async Task DeletePlayerAsync(int playerId)
    {
        var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == playerId);
        if (player != null) _context.Players.Remove(player);
        await _context.SaveChangesAsync();
    }
}