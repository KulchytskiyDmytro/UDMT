using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using NeerCore.Exceptions;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Race_Subrace;

namespace UDMT.Application.Services.Race_Subrace;

[Service]
public class RaceService : IRaceService
{
    private readonly IAppDbContext _dbContext;
    private readonly ISubRaceService _subRaceService;

    public RaceService(IAppDbContext dbContext, ISubRaceService subRaceService)
    {
        _dbContext = dbContext;
        _subRaceService = subRaceService; // Currently not used but let it be here for now
    }
    
    public async Task<ICollection<RaceDto>> GetRacesAsync(CancellationToken ct)
    {
        var races = await _dbContext.Set<Race>()
            .Include(r => r.SubRaces)
            .ProjectToType<RaceDto>()
            .ToListAsync(ct);
        
        return races;
    }

    public async Task<RaceDto> AddNewRace(RaceDto raceDto, CancellationToken ct)
    {
        var race = raceDto.Adapt<Race>();
        
        await _dbContext.Set<Race>().AddAsync(race, ct);
        await _dbContext.SaveChangesAsync(ct);
        
        return race.Adapt<RaceDto>();
    }

    public async Task<RaceDto> UpdateRaceAsync(int raceId, RaceDto raceDto, CancellationToken ct)
    {
        var race = await _dbContext.Set<Race>()
            .Include(r => r.SubRaces)
            .FirstOrDefaultAsync(r => r.Id == raceId, ct);

        if (race is null) throw new NotFoundException("No such Race");

        var raceUpdated = raceDto.Adapt(race);

        await _dbContext.SaveChangesAsync(ct);

        return raceUpdated.Adapt<RaceDto>();
    }

    public async Task DeleteRaceAsync(int raceId, CancellationToken ct)
    {
        var race = await _dbContext.Set<Race>()
            .FirstOrDefaultAsync(r => r.Id == raceId, ct);

        if (race is null) throw new NotFoundException("No such Race");

        _dbContext.Remove(race);
        await _dbContext.SaveChangesAsync(ct);
    }
}