using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UDMT.Application.DTO;
using UDMT.Application.Services.CharGenServices;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;

namespace UDMT.Application.Services;

public class PlayerService : IPlayerService
{
    private readonly AppDbContext _context;
    private IPlayerService _playerServiceImplementation;
    private ISavingThrowService _savingThrowService;

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

    public async Task<PlayerDto?> GetPlayerByIdAsync(int playerId)
    {
        return await _context.Players
            .ProjectToType<PlayerDto>()
            .FirstOrDefaultAsync(p => p.Id == playerId);
    }

    public async Task<int> AddNewPlayer(PlayerDto playerDto)
    {
        var player = playerDto.Adapt<Player>();
        _context.Players.Add(player);
        await _context.SaveChangesAsync(); // получить player.Id

        await GenerateAttributesAsync(player.Id, playerDto.RaceId);

        return player.Id;
    }

    public async Task GenerateAttributesAsync(int playerId, int raceId)
    {
        var player = await _context.Players
            .Include(p => p.Attributes)
            .FirstOrDefaultAsync(p => p.Id == playerId);

        if (player == null)
            throw new Exception($"Player {playerId} not found");

        player.Attributes.Clear(); // на случай перегенерации

        var raceBonuses = await _context.RaceAttributeBonusEnumerable
            .Where(rb => rb.RaceId == raceId)
            .ToListAsync();

        foreach (AttributeType type in Enum.GetValues<AttributeType>())
        {
            var bonus = raceBonuses.FirstOrDefault(rb => rb.AttributeType == type)?.Value ?? 0;
            player.Attributes.Add(new CharacterAttribute
            {
                AttributeType = type,
                Value = 8 + bonus
            });
        }

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<SavingThrowDto>> GenerateSavingThrowsAsync(int playerId)
    {
        // разобраться почему null на классе
        return await _savingThrowService.SavingThrowAsync(playerId);
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