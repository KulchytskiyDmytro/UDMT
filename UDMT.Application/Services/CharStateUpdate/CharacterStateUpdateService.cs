using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using UDMT.Application.Helpers;
using UDMT.Application.Services.CharGenServices;
using UDMT.Application.Services.CharGenServices.Attributes;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Characters;

namespace UDMT.Application.Services.CharStateUpdate;

[Service]
public class CharacterStateUpdateService : ICharacterStateUpdateService
{
    private readonly AppDbContext _context;
    private readonly ISavingThrowService _savingThrowService;
    private readonly IAttributeService _attributeService;

    public CharacterStateUpdateService(
        AppDbContext context, 
        ISavingThrowService savingThrowService,
        IAttributeService attributeService)
    {
        _context = context;
        _savingThrowService = savingThrowService;
        _attributeService = attributeService;
    }

    public async Task RecalculateCharacterStateAsync(int characterId)
    {
        var character = await _context.Characters
            .Include(c => c.Attributes)
            .Include(c => c.CharClass)
                .ThenInclude(cc => cc.SavingThrowProficiencies)
            .Include(c => c.CharClass)
                .ThenInclude(cc => cc.Features)!
                .ThenInclude(f => f.ClassMechanic)
            .Include(c => c.Subclass)
                .ThenInclude(sc => sc.Features)
                .ThenInclude(f => f.ClassMechanic)
            .FirstOrDefaultAsync(c => c.Id == characterId);

        if (character == null) throw new Exception("Character not found");
        
        // Attributes (если надо — от Race, Items, Features)
        
        await _attributeService.GenerateAttributesAsync(character.Id, character.RaceId);
        
        // SavingThrow (ST)
        
        await _savingThrowService.InitializeForCharacterAsync(character.Id, character.CharClassId);
        await _savingThrowService.RecalculateSavingThrowsAsync(character);
        
        // HP
        character.ApplyHp();

        // TODO: применить эффекты от Features/Mechanics

        await _context.SaveChangesAsync();
    }
}
