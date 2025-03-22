using UDMT.Application.DTO;

namespace UDMT.Application.Services.CharGenServices;

public interface IPlayerService
{
    Task<List<PlayerDto>> GetPlayersAsync();
    Task<PlayerDto?> GetPlayerByIdAsync(int playerId);
    
    Task<int> AddNewPlayer(PlayerDto playerDto);
    
    Task GenerateAttributesAsync(int playerId, int raceId);
    Task<ICollection<SavingThrowDto>> GenerateSavingThrowsAsync(int playerId);
    
    Task UpdatePlayerAsync(PlayerDto playerDto);
    Task DeletePlayerAsync(int playerId);
}