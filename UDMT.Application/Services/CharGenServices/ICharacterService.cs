using UDMT.Application.DTO;

namespace UDMT.Application.Services.CharGenServices;

public interface ICharacterService
{
    Task<ICollection<CharacterDto>> GetCharactersAsync();
    Task<CharacterDto?> GetCharacterByIdAsync(int characterId);
    
    Task<int> AddNewCharacter(CharacterDto characterDto);
    
    Task<ICollection<CharacterAttributeDto>> GenerateAttributesAsync(int characterId, int raceId);
    
    Task UpdateCharacterAsync(CharacterDto characterDto);
    Task DeleteCharacterAsync(int characterId);
}