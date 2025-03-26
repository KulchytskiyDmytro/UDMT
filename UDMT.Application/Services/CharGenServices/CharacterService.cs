using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using UDMT.Application.DTO;
using UDMT.Application.Helpers;
using UDMT.Application.Services.CharGenServices.Attributes;
using UDMT.Application.Services.CharStateUpdate;
using UDMT.Application.Services.Validation;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;
using UDMT.Domain.Entity.Characters;
using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.Services.CharGenServices;

[Service]
public class CharacterService : ICharacterService
{
    private readonly AppDbContext _context;
    private readonly IValidationService _validation;
    private readonly ICharacterStateUpdateService _characterStateUpdate;
    public CharacterService(
        AppDbContext context,
        IValidationService validationService,
        ICharacterStateUpdateService characterStateUpdate)
    {
        _context = context;
        _validation = validationService;
        _characterStateUpdate = characterStateUpdate;
    }
    
    public async Task<ICollection<CharacterDto>> GetCharactersAsync()
    {
        var characters = await _context.Characters
            .Include(p => p.Attributes)
            .Include(p => p.CharClass)
            .ThenInclude(pc => pc.SavingThrowProficiencies)
            .ToListAsync(); // <- обычный fetch

        var charactersAsync = characters.Adapt<List<CharacterDto>>();

        return charactersAsync;
    }

    public async Task<CharacterDto?> GetCharacterByIdAsync(int characterId)
    {
        var character = await _context.Characters
            .Include(p => p.Attributes)
            .Include(p => p.CharClass)
            .ThenInclude(pc => pc.SavingThrowProficiencies)
            .FirstOrDefaultAsync(p => p.Id == characterId);

        if (character is null)
            return null;
        
        var dto = character.Adapt<CharacterDto>();
        
        return dto;
    }

    public async Task<int> AddNewCharacter(CharacterDto characterDto)
    {
        var character = characterDto.Adapt<Character>();

        await _validation.ValidateClassSubclassMatchAsync(characterDto.CharClassId, characterDto.SubclassId);
        
        _context.Characters.Add(character);
        
        await _context.SaveChangesAsync(); // получить character.Id

        await _characterStateUpdate.RecalculateCharacterStateAsync(character.Id);
        
        return character.Id;
    }
    
    public async Task UpdateCharacterAsync(CharacterDto characterDto)
    {
        var character = await _context.Characters
            .Include(p => p.Attributes)
            .FirstOrDefaultAsync(p => p.Id == characterDto.Id);

        if (character == null)
            throw new Exception($"Character Id={characterDto.Id} не найден");
        
        await _validation.ValidateClassSubclassMatchAsync(characterDto.CharClassId, characterDto.SubclassId);
        
        characterDto.Adapt(character); 
        
        await _characterStateUpdate.RecalculateCharacterStateAsync(character.Id);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteCharacterAsync(int characterId)
    {
        var character = await _context.Characters
            .FirstOrDefaultAsync(p => p.Id == characterId);
        if (character != null) _context.Characters.Remove(character);
        await _context.SaveChangesAsync();
    }
}