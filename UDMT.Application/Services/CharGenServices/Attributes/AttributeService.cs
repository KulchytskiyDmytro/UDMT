using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Characters;
using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.Services.CharGenServices.Attributes;

[Service]
public class AttributeService : IAttributeService
{
    
    private readonly AppDbContext _context;

    public AttributeService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task GenerateAttributesAsync(int characterId, int raceId)
    {
        var character = await _context.Characters
            .Include(p => p.Attributes)
            .FirstOrDefaultAsync(p => p.Id == characterId);

        if (character == null)
            throw new Exception($"Character {characterId} not found");

        character.Attributes.Clear(); // на случай перегенерации

        var raceBonuses = await _context.RaceAttributeBonuses
            .Where(rb => rb.RaceId == raceId)
            .ToListAsync();

        foreach (AttributeType type in Enum.GetValues<AttributeType>())
        {
            var bonus = raceBonuses.FirstOrDefault(rb => rb.AttributeType == type)?.Value ?? 0;
            character.Attributes.Add(new CharacterAttribute
            {
                AttributeType = type,
                Value = 8 + bonus
            });
        }
    }
}