using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services.CharGenServices;

namespace UDMT.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;
    
    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }
    
    [HttpPost("add")]
    public async Task CreatePlayer([FromBody] PlayerDto playerDto)
    {
        var playerId = await _playerService.AddNewPlayer(playerDto);
        await _playerService.GenerateAttributesAsync(playerId, playerDto.RaceId);
        var savingThrows = await _playerService.GenerateSavingThrowsAsync(playerId);

        var player = await _playerService.GetPlayerByIdAsync(playerId);
        if (player is null)
        {
            throw new Exception($"Нет такого игрока {player.Id}");
        }
        player.SavingThrowDtos = savingThrows;
    }

    [HttpGet("get")]
    public async Task<List<PlayerDto>> GetPlayers()
    {
        return await _playerService.GetPlayersAsync();
    }

    [HttpPut("update")]
    public async Task UpdatePlayer([FromBody] PlayerDto playerDto)
    {
        await _playerService.UpdatePlayerAsync(playerDto);
    }

    [HttpDelete("{playerId}")]
    public async Task RemovePlayer([FromRoute] int playerId)
    {
        await _playerService.DeletePlayerAsync(playerId);
    }
    
}