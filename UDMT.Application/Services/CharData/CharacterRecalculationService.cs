using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using NeerCore.Exceptions;
using UDMT.Application.Helpers;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Char;
using UDMT.Domain.Entity.Race_Subrace;
using UDMT.Domain.Entity.Tech.Mod;

namespace UDMT.Application.Services.CharData;

[Service]
public class CharacterRecalculationService : ICharacterRecalculationService
{
    private readonly IAppDbContext _dbContext;
    private readonly ICharacterModifierService _characterModifier;

    public CharacterRecalculationService(IAppDbContext dbContext,
        ICharacterModifierService characterModifier)
    {
        _dbContext = dbContext;
        _characterModifier = characterModifier;
    }
    
    // TODO: Fix that shit someday 
    public async Task RecalculateCharacterStateAsync(int characterId, CancellationToken ct)
    {
        var character = await _dbContext.Set<Character>()
            .FirstOrDefaultAsync(c => c.Id == characterId, cancellationToken: ct);

        if (character is null) throw new NotFoundException($"There is no such character with Id: {characterId}");
        
        // I mean WTF is that
        var background = await ModifierRelationFactory.GetModifiersBySourceIdAsync(_dbContext, character.BackgroundId, ModifierSourceType.Background, ct);

        var race = await ModifierRelationFactory.GetModifiersBySourceIdAsync(_dbContext, character.RaceId, ModifierSourceType.Race, ct);
        
        int subraceId = await _dbContext.Set<SubRace>()
            .Where(sr => sr.RaceId == character.RaceId)
            .Select(sr => sr.Id)
            .FirstOrDefaultAsync(ct);
        
        var subrace = await ModifierRelationFactory.GetModifiersBySourceIdAsync(_dbContext,subraceId, ModifierSourceType.Subrace, ct); 
        
        await _characterModifier.ApplyModifiers(characterId, race, ct);
        
        await _characterModifier.ApplyModifiers(characterId, subrace, ct);
        
        await _characterModifier.ApplyModifiers(characterId, background, ct);
    }
}