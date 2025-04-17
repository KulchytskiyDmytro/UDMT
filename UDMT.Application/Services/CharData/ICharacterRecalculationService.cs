namespace UDMT.Application.Services.CharData;

public interface ICharacterRecalculationService
{
    Task RecalculateCharacterStateAsync(int characterId, CancellationToken ct);
}