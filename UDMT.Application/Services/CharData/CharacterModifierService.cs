using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
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
    
    public async Task ApplyModifiers(int characterId, IEnumerable<ModifierDto> mDtos, CancellationToken ct)
    {
        foreach (var mDto in mDtos)
        {
            switch (mDto.ModifierType)
            {
                case ModifierType.AttributeBonus:
                    await ApplyAttributeModifierAsync(characterId, mDto, ct);
                    break;
                
                // сюда можно добавить другие ModifierType, например AC, Speed, и т.д.
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(mDto.ModifierType),
                        $"Unsupported modifier type: {mDto.ModifierType}");
            }
        }
    }

    private async Task ApplyAttributeModifierAsync(int characterId, ModifierDto mDto, CancellationToken ct)
    {
        var attributes = await _dbContext.Set<CharAttribute>()
            .Where(a => a.CharacterId == characterId)
            .ToListAsync(ct);
        
        var attr = attributes
            .FirstOrDefault(a => a.AttributeType == mDto.AttributeType);
        if (attr != null)
            attr.Value += mDto.Value ?? 0;

        // 3) Сохраняем все изменения одним запросом
        await _dbContext.SaveChangesAsync(ct);
        
    }

    private void ApplySavingThrowModifier(Character character, ModifierDto mDto)
    {
        throw new NotImplementedException();
    }

    private void ApplySkillModifier(Character character, ModifierDto mDto)
    {
        throw new NotImplementedException();
    }
}