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
    private readonly ISavingThrowService _savingThrowService;

    public PlayerService(AppDbContext context, ISavingThrowService savingThrowService)
    {
        _context = context;
        _savingThrowService = savingThrowService;
    }
    
    public async Task<List<PlayerDto>> GetPlayersAsync()
    {
        var players = await _context.Players
            .Include(p => p.Attributes)
            .Include(p => p.PlayerClass)
            .ThenInclude(pc => pc.SavingThrowProficiencies)
            .ToListAsync(); // <- обычный fetch

        var playersList = players.Adapt<List<PlayerDto>>();

        foreach (var dto in playersList)
        {
            dto.SavingThrowDtos = await _savingThrowService.CalcSavingThrowAsync(dto.Id);
        }

        return playersList;
    }

    public async Task<PlayerDto?> GetPlayerByIdAsync(int playerId)
    {
        var player = await _context.Players
            .Include(p => p.Attributes)
            .Include(p => p.PlayerClass)
            .ThenInclude(pc => pc.SavingThrowProficiencies)
            .FirstOrDefaultAsync(p => p.Id == playerId);

        if (player is null)
            return null;

        var dto = player.Adapt<PlayerDto>();
        dto.SavingThrowDtos = await _savingThrowService.CalcSavingThrowAsync(playerId);

        return dto;
    }

    public async Task<int> AddNewPlayer(PlayerDto playerDto)
    {
        var player = playerDto.Adapt<Player>();
        _context.Players.Add(player);
        await _context.SaveChangesAsync(); // получить player.Id

        await GenerateAttributesAsync(player.Id, playerDto.RaceId);

        await GenerateSavingThrowsAsync(player.Id);
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
        return await _savingThrowService.CalcSavingThrowAsync(playerId);
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