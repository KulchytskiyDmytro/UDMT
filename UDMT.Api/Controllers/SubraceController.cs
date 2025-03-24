using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services;
using UDMT.Application.Services.CharGenServices;

namespace UDMT.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubraceController : ControllerBase
{
    private readonly ISubraceService _subraceService;
    
    public SubraceController(ISubraceService subraceService)
    {
        _subraceService = subraceService;
    }
    
    [HttpPost("add")]
    public async Task CreateSubrace([FromBody] SubraceDto subraceDto)
    {
        await _subraceService.AddNewSubRaceAsync(subraceDto);
    }
    
    [HttpGet("get")]
    public async Task<List<SubraceDto>> GetSubrace()
    {
        return await _subraceService.GetSubRacesAsync();
    }
        
    [HttpPut("update")]
    public async Task UpdateSubrace([FromBody] SubraceDto subraceDto)
    {
        await _subraceService.UpdateSubRaceAsync(subraceDto);
    }

    [HttpDelete("{raceId}")]
    public async Task RemoveSubrace([FromRoute] int subraceId)
    {
        await _subraceService.DeleteSubRaceAsync(subraceId);
    }
}