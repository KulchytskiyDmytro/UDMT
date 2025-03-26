using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using UDMT.Application.DTO;
using UDMT.Application.Helpers;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;
using UDMT.Domain.Entity.Characters;
using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.Services.CharGenServices;

[Service]
public class SavingThrowService : ISavingThrowService
{
    private readonly AppDbContext _context;

    public SavingThrowService(AppDbContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Get SavingThrow
    /// </summary>
    public async Task<ICollection<CharacterSavingThrowDto>> GetSavingThrowsAsync(int characterId)
    {
        
        var character = await _context.Characters
            .Include(c => c.CharClass)
                .ThenInclude(cc => cc.SavingThrowProficiencies)
            .Include(c => c.SavingThrows)
            .FirstOrDefaultAsync(c => c.Id == characterId);

        if (character == null)
            throw new Exception($"Character with Id={characterId} not found.");

        var proficiencyBonus = character.CharClass.ProficencyBonus;
        
        var classProficiencies = character.CharClass.SavingThrowProficiencies
            .Select(p => p.AttributeType);
        
        var attributeValues = await _context.CharacterAttributes
            .Where(a => a.CharacterId == characterId)
            .ToDictionaryAsync(a => a.AttributeType, a => a.Value);
        
        var result = Enum.GetValues<AttributeType>()
            .Select(attrType =>
            {
                var baseValue = attributeValues.TryGetValue(attrType, out var value) ? value : 10;
                
                // NOTE: For future (Items, spells ect. can add or remove values)
                var totalScore = baseValue;
                
                var modifier = AttributeUtils.GetModifier(totalScore);

                var existing = character.SavingThrows
                    .FirstOrDefault(st => st.AttributeType == attrType);

                var dto = new CharacterSavingThrowDto
                {
                    Attribute = attrType,
                    IsProficient = classProficiencies.Contains(attrType),
                    ProficiencyBonus = proficiencyBonus,
                    AttributeModifier = modifier,
                    BonusOverride = existing?.BonusOverride ?? 0
                };

                dto.Total = dto.GetSavingThrowBonus(totalScore);

                return dto;
            })
            .ToList();

        return result;
    }

    /// <summary>
    /// Create SavingThrow
    /// </summary>
    public async Task InitializeForCharacterAsync(int charId, int charClassId)
    {
        var existing = await _context.CharacterSavingThrows
            .Where(x => x.CharacterId == charId)
            .ToListAsync();
        
        if (existing.Any()) return;

        var classProficiencies = await _context.CharClassSavingThrows
            .Where(x => x.CharClassId == charClassId)
            .Select(x => x.AttributeType)
            .ToListAsync();
        
        var profs = classProficiencies.ToHashSet();
        
        var savingThrows = Enum.GetValues<AttributeType>().Select(attr => new CharacterSavingThrow
        {
            CharacterId = charId,
            AttributeType = attr,
            IsProficient = profs.Contains(attr),
            BonusOverride = 0
        });
        
        await _context.CharacterSavingThrows.AddRangeAsync(savingThrows);
    }

    
    /// <summary>
    /// Update SavingThrow
    /// </summary>
    public async Task UpdateSavingThrowAsync(int characterId, CharacterSavingThrowDto dto)
    {
        var entity = await _context.CharacterSavingThrows
            .FirstOrDefaultAsync(x => x.CharacterId == characterId && x.AttributeType == dto.Attribute);

        if (entity == null)
            throw new Exception("Saving throw not found.");

        entity.IsProficient = dto.IsProficient;
        entity.BonusOverride = dto.BonusOverride;

        
    }
    
    /// <summary>
    /// Shared SavingThrow Get + Update
    /// </summary>
    public async Task RecalculateSavingThrowsAsync(Character character)
    {
        var recalculated = await GetSavingThrowsAsync(character.Id);

        var existing = await _context.CharacterSavingThrows
            .Where(x => x.CharacterId == character.Id)
            .ToListAsync();

        foreach (var dto in recalculated)
        {
            var entity = existing.FirstOrDefault(e => e.AttributeType == dto.Attribute);
            if (entity is not null)
            {
                entity.IsProficient = dto.IsProficient;
                entity.BonusOverride = dto.BonusOverride;
            }
        }
    }
}