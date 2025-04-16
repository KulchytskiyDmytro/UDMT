using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using NeerCore.Exceptions;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Race_Subrace;

namespace UDMT.Application.Services.Race_Subrace;

[Service]
public class SubRaceService : ISubRaceService
{
    private readonly IAppDbContext _dbContext;

    public SubRaceService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<SubRaceDto> CreateSubraceAsync(int raceId, SubRaceDto dto, CancellationToken ct)
    {
        var race = await _dbContext.Set<Race>()
            .Include(r => r.SubRaces)
            .FirstOrDefaultAsync(r => r.Id == raceId, ct);
        
        if (race is null) throw new NotFoundException("Race not found");
        
        var subRace = dto.Adapt<SubRace>();
        subRace.RaceId = race.Id;
        
        _dbContext.Set<SubRace>().Add(subRace);  
        await _dbContext.SaveChangesAsync(ct);

        return subRace.Adapt<SubRaceDto>();
    }

    public async Task<SubRaceDto> UpdateSubraceAsync(int raceId, SubRaceDto dto, CancellationToken ct)
    {
        var race = await _dbContext.Set<Race>()
            .Include(r => r.SubRaces)
            .FirstOrDefaultAsync(r => r.Id == raceId, ct);
        
        if (race is null) throw new NotFoundException("Race not found");
        
        var subrace = await _dbContext.Set<SubRace>()
            .FirstOrDefaultAsync(sr => sr.RaceId == raceId, ct);

        if (subrace is null)
            throw new NotFoundException("SubRace not found for the given Race");

        dto.Adapt(subrace);

        await _dbContext.SaveChangesAsync(ct);

        return subrace.Adapt<SubRaceDto>();
    }

    public async Task DeleteSubraceAsync(int raceId, CancellationToken ct)
    {
        var subrace = await _dbContext.Set<SubRace>()
            .FirstOrDefaultAsync(sr => sr.RaceId == raceId, ct);

        if (subrace is null)
            throw new NotFoundException("SubRace not found for the given Race");

        _dbContext.Remove(subrace);
        await _dbContext.SaveChangesAsync(ct);
    }
}