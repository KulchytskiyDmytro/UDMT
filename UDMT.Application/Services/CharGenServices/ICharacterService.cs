using UDMT.Application.DTO;

namespace UDMT.Application.Services.CharGenServices;

public interface ICharacterService
{
    Task<List<CharacterDto>> GetCharactersAsync();
    Task<CharacterDto?> GetCharacterByIdAsync(int characterId);
    
    Task<int> AddNewCharacter(CharacterDto characterDto);
    
    Task GenerateAttributesAsync(int characterId, int raceId);
    
    Task UpdateCharacterAsync(CharacterDto characterDto);
    Task DeleteCharacterAsync(int characterId);
}