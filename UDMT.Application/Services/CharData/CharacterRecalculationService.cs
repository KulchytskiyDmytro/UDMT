using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using NeerCore.Exceptions;
using UDMT.Application.Helpers;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Char;

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

    
    public async Task RecalculateCharacterStateAsync(int characterId, CancellationToken ct)
    {
        var character = await _dbContext.Set<Character>()
            .FirstOrDefaultAsync(c => c.Id == characterId, cancellationToken: ct);

        if (character is null) throw new NotFoundException($"There is no such character with Id: {characterId}");

        var background = await ModifierRelationFactory.GetModifiersBySourceIdAsync(_dbContext, character.BackgroundId, ct);
        _characterModifier.ApplyModifiers(character.Id, background, ct);
    }
}