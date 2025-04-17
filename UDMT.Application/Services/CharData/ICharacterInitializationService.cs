using UDMT.Domain.Entity.Char;

namespace UDMT.Application.Services.CharData;

public interface ICharacterInitializationService
{
    Task InitializeCharacterAsync(int characterId, CancellationToken ct);
}