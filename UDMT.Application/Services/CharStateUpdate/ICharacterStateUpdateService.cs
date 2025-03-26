namespace UDMT.Application.Services.CharStateUpdate;

public interface ICharacterStateUpdateService
{
    Task RecalculateCharacterStateAsync(int characterId);
}