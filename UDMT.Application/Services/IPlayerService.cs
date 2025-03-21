using UDMT.Application.DTO;
using UDMT.Domain.Entity;

namespace UDMT.Application.Services;

public interface IPlayerService
{
    Task<List<Player>> GetPlayersAsync();
    Task AddNewPlayer(PlayerDto playerDto);
    Task UpdatePlayerAsync(PlayerDto playerDto);
    Task DeletePlayerAsync(int playerId);
}