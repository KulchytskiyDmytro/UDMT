using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using NeerCore.Exceptions;
using UDMT.Application.Helpers;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;
using UDMT.Domain.Entity.Char;
using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.Services.CharData;

[Service]
public class CharacterInitializationService : ICharacterInitializationService
{
    private readonly AppDbContext _dbContext;

    public CharacterInitializationService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task InitializeCharacterAsync(int characterId, CancellationToken ct)
    {
        await GenerateCharAttributes(characterId, ct);
        await GenerateCharSavingThrows(characterId, ct);
        await GenerateCharSkills(characterId, ct);
        
        await _dbContext.SaveChangesAsync(ct);
    }
    
    private async Task GenerateCharAttributes(int characterId, CancellationToken ct)
    {
        var attrs = Enum.GetValues<AttributeType>()
            .Select(type => new CharAttribute
            {
                CharacterId   = characterId,
                AttributeType = type,
                Value         = 8,
                BonusModifier = -1
            })
            .ToList();
        
        await _dbContext.Set<CharAttribute>()
            .AddRangeAsync(attrs, ct);
    }

    private async Task GenerateCharSavingThrows(int characterId, CancellationToken ct)
    {
        var sList = Enum.GetValues<AttributeType>()
            .Select(type => new CharSavingThrow()
            {
                CharacterId   = characterId,
                AttributeType = type,
                BonusModifier = -1
            })
            .ToList();
        
        await _dbContext.Set<CharSavingThrow>()
            .AddRangeAsync(sList, ct);
    }
    
    private async Task GenerateCharSkills(int characterId, CancellationToken ct)
    {
        var skillIds = await _dbContext.Set<Skill>()
            .Where(s => !s.IsHomebrew)
            .Select(s => s.Id)
            .ToListAsync(ct);
        
        var skillList = skillIds
            .Select(skillId => new CharSkill
            {
                CharacterId = characterId,
                SkillId = skillId,
                ProficiencyType = ProficiencyType.None,
                BonusModifier = -1
            })
            .ToList();

        await _dbContext.Set<CharSkill>()
            .AddRangeAsync(skillList, ct);
    }
}