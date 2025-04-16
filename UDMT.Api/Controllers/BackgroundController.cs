using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services;

namespace UDMT.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BackgroundController : ControllerBase
{
    private readonly IBackgroundService _backgroundService;
    
    public BackgroundController(IBackgroundService backgroundService)
    {
        _backgroundService = backgroundService;
    }
    
    [HttpPost("add")]
    public async Task CreateRace([FromBody] BackgroundDto dto, CancellationToken ct)
    {
        await _backgroundService.AddNewBackground(dto, ct);
    }

    [HttpGet("get")]
    public async Task<ICollection<GetBackgroundsDto>> GetRaces(CancellationToken ct)
    {
        return await _backgroundService.GetBackgroundAsync(ct);
    }

    [HttpPut("update/{bgId}")]
    public async Task<BackgroundDto> UpdateRace([FromRoute] int bgId, 
        [FromBody] BackgroundDto dto, CancellationToken ct)
    {
        return await _backgroundService.UpdateBackgroundAsync(bgId, dto, ct);
    }
    
    [HttpDelete("delete/{bgId}")]
    public async Task DeleteRace([FromRoute] int bgId, CancellationToken ct)
    {
        await _backgroundService.DeleteBackgroundAsync(bgId, ct);
    }
}