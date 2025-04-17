using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services.Race_Subrace;

namespace UDMT.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RaceController : ControllerBase
{
    private readonly IRaceService _raceService;
    
    public RaceController(IRaceService raceService)
    {
        _raceService = raceService;
    }
    
    [HttpPost("add")]
    public async Task CreateRace([FromBody] RaceDto raceDto, CancellationToken ct)
    {
        await _raceService.AddNewRace(raceDto, ct);
    }

    [HttpGet("get")]
    public async Task<ICollection<GetRacesDto>> GetRaces(CancellationToken ct)
    {
        return await _raceService.GetRacesAsync(ct);
    }

    [HttpPut("update/{raceId}")]
    public async Task<RaceDto> UpdateRace([FromRoute] int raceId, 
        [FromBody] RaceDto raceDto, CancellationToken ct)
    {
        return await _raceService.UpdateRaceAsync(raceId, raceDto, ct);
    }
    
    [HttpDelete("delete/{raceId}")]
    public async Task DeleteRace([FromRoute] int raceId, CancellationToken ct)
    {
        await _raceService.DeleteRaceAsync(raceId, ct);
    }
}