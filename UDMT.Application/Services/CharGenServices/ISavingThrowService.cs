using UDMT.Application.DTO;
using UDMT.Domain.Entity;
using UDMT.Domain.Entity.Characters;

namespace UDMT.Application.Services.CharGenServices;

public interface ISavingThrowService
{
        
    /// <summary>
    /// Get SavingThrow
    /// </summary>
    Task<ICollection<CharacterSavingThrowDto>> GetSavingThrowsAsync(int characterId);
    
    /// <summary>
    /// Create SavingThrow
    /// </summary>
    Task InitializeForCharacterAsync(int charId, int charClassId);
    
    /// <summary>
    /// Update SavingThrow
    /// </summary>
    Task UpdateSavingThrowAsync(int characterId, CharacterSavingThrowDto dto);
    
    /// <summary>
    /// Shared SavingThrow Get + Update
    /// </summary>
    Task RecalculateSavingThrowsAsync(Character character);
}