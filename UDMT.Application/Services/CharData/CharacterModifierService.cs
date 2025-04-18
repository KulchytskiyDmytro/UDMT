using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using NeerCore.Exceptions;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Char;
using UDMT.Domain.Entity.Tech.Mod;

namespace UDMT.Application.Services.CharData;

[Service]
public class CharacterModifierService : ICharacterModifierService
{
    private readonly AppDbContext _dbContext;

    public CharacterModifierService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task ApplyModifiers(int characterId, ICollection<ModifierDto> mDtos, CancellationToken ct)
    {
        foreach (var mDto in mDtos)
        {
            switch (mDto.ModifierType)
            {
                case ModifierType.AttributeBonus:
                    await ApplyAttributeModifierAsync(characterId, mDto, ct);
                    break;
                case ModifierType.SavingThrowBonus:
                    await ApplySavingThrowModifierAsync(characterId, mDto, ct);
                    break;
                case ModifierType.SkillBonus:
                    await ApplySkillModifier(characterId, mDto, ct);
                    break;
                case ModifierType.Speed:
                    await ApplySpeedModifierAsync(characterId, mDto, ct);
                    break;
                case ModifierType.ArmorClass:
                    await ApplyArmorClassAsync(characterId, mDto, ct);
                    break;
                case ModifierType.Initiative:
                    await ApplyInitiativeAsync(characterId, mDto, ct);
                    break;
                case ModifierType.CurrentHp:
                    await ApplyCurrentHpAsync(characterId, mDto, ct);
                    break;
                case ModifierType.TemporaryHp:
                    await ApplyTemporaryHpAsync(characterId, mDto, ct);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(mDto.ModifierType),
                        $"Unsupported modifier type: {mDto.ModifierType}");
            }
        }
    }

    private async Task ApplyAttributeModifierAsync(int characterId, ModifierDto mDto, CancellationToken ct)
    {
        var attr = await _dbContext.Set<CharAttribute>()
            .FirstOrDefaultAsync(a =>
                a.CharacterId == characterId &&
                a.AttributeType == mDto.AttributeType, ct);

        if (attr != null)
            attr.Value += mDto.Value ?? throw new NotFoundException($"Character with Id {characterId} not found");

        await _dbContext.SaveChangesAsync(ct);
    }

    private async Task ApplySavingThrowModifierAsync(int characterId, ModifierDto mDto, CancellationToken ct)
    {
        var savingThrows = await _dbContext.Set<CharSavingThrow>()
            .FirstOrDefaultAsync(st =>
                st.CharacterId == characterId &&
                st.AttributeType == mDto.AttributeType, ct);
        
        if (savingThrows != null)
            savingThrows.BonusModifier += mDto.Value ?? throw new NotFoundException($"Character with Id {characterId} not found");

        await _dbContext.SaveChangesAsync(ct);
    }

    private async Task ApplySkillModifier(int characterId, ModifierDto mDto, CancellationToken ct)
    {
        var skill = await _dbContext.Set<CharSkill>()
            .FirstOrDefaultAsync(s =>
                s.CharacterId == characterId &&
                s.SkillId == mDto.SkillId, ct);
        
        if (skill != null)
        {
            skill.BonusModifier += mDto.Value ?? 0;
            skill.ProficiencyType = mDto.ProficiencyType;
        }
        else throw new NotFoundException($"Character with Id {characterId} not found");
        
        await _dbContext.SaveChangesAsync(ct);
    }
    
    private async Task ApplySpeedModifierAsync(int characterId, ModifierDto mDto, CancellationToken ct)
    {
        var character = await _dbContext.Set<Character>()
            .FirstOrDefaultAsync(ch => ch.Id == characterId, ct);
        
        if (character != null)
            character.Speed += mDto.Value ?? throw new NotFoundException($"Character with Id {characterId} not found");

        await _dbContext.SaveChangesAsync(ct);
    }
    
    private async Task ApplyArmorClassAsync(int characterId, ModifierDto mDto, CancellationToken ct)
    {
        var character = await _dbContext.Set<Character>()
            .FirstOrDefaultAsync(ch => ch.Id == characterId, ct);
        
        if (character != null)
            character.ArmorClass += mDto.Value ?? throw new NotFoundException($"Character with Id {characterId} not found");

        await _dbContext.SaveChangesAsync(ct);
    }
    
    private async Task ApplyInitiativeAsync(int characterId, ModifierDto mDto, CancellationToken ct)
    {
        var character = await _dbContext.Set<Character>()
            .FirstOrDefaultAsync(ch => ch.Id == characterId, ct);
        
        if (character != null)
            character.Initiative += mDto.Value ?? throw new NotFoundException($"Character with Id {characterId} not found");

        await _dbContext.SaveChangesAsync(ct);
    }
    
    private async Task ApplyCurrentHpAsync(int characterId, ModifierDto mDto, CancellationToken ct)
    {
        var character = await _dbContext.Set<Character>()
            .FirstOrDefaultAsync(ch => ch.Id == characterId, ct);
        
        if (character != null)
            character.CurrentHp += mDto.Value ?? throw new NotFoundException($"Character with Id {characterId} not found");

        await _dbContext.SaveChangesAsync(ct);
    }
    
    private async Task ApplyTemporaryHpAsync(int characterId, ModifierDto mDto, CancellationToken ct)
    {
        var character = await _dbContext.Set<Character>()
            .FirstOrDefaultAsync(ch => ch.Id == characterId, ct);
        
        if (character != null)
            character.TemporaryHp += mDto.Value ?? throw new NotFoundException($"Character with Id {characterId} not found");

        await _dbContext.SaveChangesAsync(ct);
    }
}