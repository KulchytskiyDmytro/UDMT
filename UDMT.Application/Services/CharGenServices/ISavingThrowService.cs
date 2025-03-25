using UDMT.Application.DTO;
using UDMT.Domain.Entity;

namespace UDMT.Application.Services.CharGenServices;

public interface ISavingThrowService
{
    Task<ICollection<CharacterSavingThrowDto>> GetSavingThrowsAsync(int characterId);
    Task InitializeForCharacterAsync(int charId, int charClassId);
    Task UpdateAsync(int characterId, CharacterSavingThrowDto dto);
}