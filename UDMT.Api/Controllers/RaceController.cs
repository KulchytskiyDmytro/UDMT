﻿using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services;
using UDMT.Application.Services.CharGenServices;

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
    public async Task CreateRace([FromBody] RaceDto raceDto)
    {
        await _raceService.AddNewRace(raceDto);
    }
    
    [HttpGet("get")]
    public async Task<ICollection<RaceDto>> GetRace()
    {
        return await _raceService.GetRacesAsync();
    }
    
    [HttpPut("update")]
    public async Task UpdateRace([FromBody] RaceDto raceDto)
    {
        await _raceService.UpdateRaceAsync(raceDto);
    }

    [HttpDelete("{raceId}")]
    public async Task RemoveRace([FromRoute] int raceId)
    {
        await _raceService.DeleteRaceAsync(raceId);
    }
}