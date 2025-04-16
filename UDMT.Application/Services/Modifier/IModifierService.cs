using UDMT.Application.DTO;

namespace UDMT.Application.Services.Modifier;

public interface IModifierService
{
    Task<ICollection<ModifierDto>> GetModifiersAsync(CancellationToken ct);
    Task<ModifierDto> AddNewModifier(ModifierDto modifierDto, CancellationToken ct);
    Task<ModifierDto> UpdateModifierAsync(int bgId, ModifierDto modifierDto, CancellationToken ct);
    Task DeleteModifierAsync(int modifierId, CancellationToken ct);
}