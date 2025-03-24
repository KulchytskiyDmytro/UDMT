using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using UDMT.Application.DTO;
using UDMT.Application.Helpers;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;

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
            .Include(c => c.Attributes)
            .Include(c => c.SavingThrows)
            .FirstOrDefaultAsync(c => c.Id == characterId);

        if (character is null)
            throw new Exception($"Character with Id={characterId} not found.");

        var proficiencyBonus = character.ProficencyBonus;

        return character.SavingThrows.Select(st =>
        {
            var score = character.Attributes.FirstOrDefault(a => a.AttributeType == st.AttributeType)?.Value ?? 10;
            var modifier = AttributeUtils.GetModifier(score);

            var dto = new CharacterSavingThrowDto
            {
                Attribute = st.AttributeType,
                IsProficient = st.IsProficient,
                ProficiencyBonus = proficiencyBonus,
                AttributeModifier = modifier,
                BonusOverride = st.BonusOverride,
            };

            dto.Total = AttributeUtils.GetSavingThrowBonus(score, dto);
            
            return dto;
        }).ToList();
    }

    /// <summary>
    /// Create SavingThrow
    /// </summary>
    public async Task InitializeForCharacterAsync(int characterId, IEnumerable<AttributeType> proficientAttributes)
    {
        var existing = await _context.CharacterSavingThrows
            .Where(x => x.CharacterId == characterId)
            .ToListAsync();
        
        if (existing.Any()) return;

        var profs = proficientAttributes.ToHashSet();
        
        var savingThrows = Enum.GetValues<AttributeType>().Select(attr => new CharacterSavingThrow
        {
            CharacterId = characterId,
            AttributeType = attr,
            IsProficient = profs.Contains(attr),
            BonusOverride = 0
        });
        
        await _context.CharacterSavingThrows.AddRangeAsync(savingThrows);
        await _context.SaveChangesAsync();
    }

    
    /// <summary>
    /// Update SavingThrow
    /// </summary>
    public async Task UpdateAsync(int characterId, CharacterSavingThrowDto dto)
    {
        var entity = await _context.CharacterSavingThrows
            .FirstOrDefaultAsync(x => x.CharacterId == characterId && x.AttributeType == dto.Attribute);

        if (entity == null)
            throw new Exception("Saving throw not found.");

        entity.IsProficient = dto.IsProficient;
        entity.BonusOverride = dto.BonusOverride;

        await _context.SaveChangesAsync();
    }
}