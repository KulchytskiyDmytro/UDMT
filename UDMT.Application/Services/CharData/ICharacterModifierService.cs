using UDMT.Application.DTO;
using UDMT.Domain.Entity.Char;

namespace UDMT.Application.Services.CharData;

public interface ICharacterModifierService
{
    Task ApplyModifiers(int characterId, ICollection<ModifierDto> mDtos, CancellationToken ct);
    
}