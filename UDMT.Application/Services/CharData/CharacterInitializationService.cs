using NeerCore.DependencyInjection;
using UDMT.Application.Helpers;
using UDMT.Domain.Context;
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
        await GenerateAttributes(characterId, ct);
        await GenerateSavingThrows(characterId, ct);
            
        await _dbContext.SaveChangesAsync(ct);
    }
    
    private async Task GenerateAttributes(int characterId, CancellationToken ct)
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
        
        await _dbContext.SaveChangesAsync(ct);
    }

    private async Task GenerateSavingThrows(int characterId, CancellationToken ct)
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
        
        await _dbContext.SaveChangesAsync(ct);
    }
    
    // TODO: Rethink Skill Entity 
    // наверное стоит отказатся на время от кастомных скилов и строго типизировать их
    private void GenerateSkills(Character character)
    {
        foreach (AttributeType type in Enum.GetValues<AttributeType>())
        {
            character.SavingThrows.Add(new CharSavingThrow()
            {
                CharacterId = character.Id,
                AttributeType = type
            });
        }
    }
}