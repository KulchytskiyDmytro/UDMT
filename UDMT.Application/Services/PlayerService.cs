using Mapster;
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
    
    public async Task<List<PlayerDto>> GetPlayersAsync()
    {
        return await _context.Players
            .ProjectToType<PlayerDto>() 
            .ToListAsync();
    }

    public async Task AddNewPlayer(PlayerDto playerDto)
    {
        var player = playerDto.Adapt<Player>();

        var raceBonuses = await _context.RaceAttributeBonusEnumerable
            .Where(rb => rb.RaceId == playerDto.RaceId)
            .ToListAsync();
        
        foreach (AttributeType type in Enum.GetValues(typeof(AttributeType)))
        {
            var bonus = raceBonuses.FirstOrDefault(b => b.AttributeType == type)?.Value ?? 0;
            
            player.Attributes.Add(new CharacterAttribute
            {
                AttributeType = type,
                Value = 8 + bonus,
                
            });
        }

        player.Adapt<PlayerDto>();
        
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePlayerAsync(PlayerDto playerDto)
    {
        var player = await _context.Players
            .Include(p => p.Attributes)
            .FirstOrDefaultAsync(p => p.Id == playerDto.Id);

        if (player == null)
            throw new Exception($"Player Id={playerDto.Id} не найден");

        // Обновить свойства
        playerDto.Adapt(player); // in-place map

        // Обновить атрибуты вручную
        player.Attributes = playerDto.CharacterAttributes.Adapt<ICollection<CharacterAttribute>>();

        await _context.SaveChangesAsync();
    }

    public async Task DeletePlayerAsync(int playerId)
    {
        var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == playerId);
        if (player != null) _context.Players.Remove(player);
        await _context.SaveChangesAsync();
    }
}