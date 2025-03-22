using UDMT.Application.DTO;

namespace UDMT.Application.Services.CharGenServices;

public interface IPlayerService
{
    Task<List<PlayerDto>> GetPlayersAsync();
    Task AddNewPlayer(PlayerDto playerDto);
    Task UpdatePlayerAsync(PlayerDto playerDto);
    Task DeletePlayerAsync(int playerId);
}