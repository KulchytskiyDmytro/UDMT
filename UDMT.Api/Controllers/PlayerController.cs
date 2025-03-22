using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services;
using UDMT.Domain.Entity;

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
        await _playerService.AddNewPlayer(playerDto);
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