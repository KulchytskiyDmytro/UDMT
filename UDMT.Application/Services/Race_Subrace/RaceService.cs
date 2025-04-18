using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using NeerCore.Exceptions;
using UDMT.Application.DTO;
using UDMT.Application.Helpers;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Race_Subrace;
using UDMT.Domain.Entity.Tech.Mod;

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
    
    public async Task<ICollection<GetRacesDto>> GetRacesAsync(CancellationToken ct)
    {
        var races = await _dbContext.Set<Race>()
            .Include(r => r.SubRaces)
            .ProjectToType<GetRacesDto>()
            .ToArrayAsync(ct);
        
        await ModifierRelationFactory.BindModifierRelationsAsync(_dbContext, races, 
            ModifierSourceType.Race, ct);
        
        return races;
    }

    public async Task<RaceDto> AddNewRace(RaceDto raceDto, CancellationToken ct)
    {
        var race = raceDto.Adapt<Race>();
        
        await _dbContext.Set<Race>().AddAsync(race, ct);
        await _dbContext.SaveChangesAsync(ct);
        
        if (raceDto.ModifierIds is not null)
        {
            await ModifierRelationFactory.SetModifierRelationAsync(_dbContext, raceDto.ModifierIds, 
                race.Id, ModifierSourceType.Race, ct);
        }
        
        return race.Adapt<RaceDto>();
    }

    public async Task<RaceDto> UpdateRaceAsync(int raceId, RaceDto raceDto, CancellationToken ct)
    {
        var race = await _dbContext.Set<Race>()
            .Include(r => r.SubRaces)
            .FirstOrDefaultAsync(r => r.Id == raceId, ct);

        if (race is null) throw new NotFoundException("No such Race");

        raceDto.Adapt(race);
        
        await ModifierRelationFactory.UpdateModifiersAsync(_dbContext, raceId,
            ModifierSourceType.Race, raceDto.ModifierIds!, ct);
        
        await _dbContext.SaveChangesAsync(ct);
        
        return race.Adapt<RaceDto>();
    }

    public async Task DeleteRaceAsync(int raceId, CancellationToken ct)
    {
        var race = await _dbContext.Set<Race>()
            .FirstOrDefaultAsync(r => r.Id == raceId, ct);

        if (race is null) throw new NotFoundException("No such Race");

        await ModifierRelationFactory.RemoveModifierRelationsBySourceAsync(_dbContext, raceId,
            ModifierSourceType.Race, ct);
        
        _dbContext.Remove(race);
        await _dbContext.SaveChangesAsync(ct);
    }
}