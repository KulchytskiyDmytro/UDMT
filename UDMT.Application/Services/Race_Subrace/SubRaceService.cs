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

        if (dto.ModifierIds is not null)
        {
            await ModifierRelationFactory.SetModifierRelationAsync(_dbContext, dto.ModifierIds, 
                subRace.Id, ModifierSourceType.Subrace, ct);
        }
        
        return subRace.Adapt<SubRaceDto>();
    }

    public async Task<SubRaceDto> UpdateSubraceAsync(int raceId, SubRaceDto subRaceDto, CancellationToken ct)
    {
        var race = await _dbContext.Set<Race>()
            .Include(r => r.SubRaces)
            .FirstOrDefaultAsync(r => r.Id == raceId, ct);
        
        if (race is null) throw new NotFoundException("Race not found");
        
        var subRace = await _dbContext.Set<SubRace>()
            .FirstOrDefaultAsync(sr => sr.RaceId == raceId, ct);

        if (subRace is null)
            throw new NotFoundException("SubRace not found for the given Race");

        subRaceDto.Adapt(subRace);

        if (subRaceDto.ModifierIds is not null)
        {
            await ModifierRelationFactory.SetModifierRelationAsync(_dbContext, subRaceDto.ModifierIds, 
                subRace.Id, ModifierSourceType.Subrace, ct);
        }
        
        await _dbContext.SaveChangesAsync(ct);

        return subRace.Adapt<SubRaceDto>();
    }

    public async Task DeleteSubraceAsync(int raceId, CancellationToken ct)
    {
        var subRace = await _dbContext.Set<SubRace>()
            .FirstOrDefaultAsync(sr => sr.RaceId == raceId, ct);

        if (subRace is null)
            throw new NotFoundException("SubRace not found for the given Race");

        await ModifierRelationFactory.RemoveModifierRelationsBySourceAsync(_dbContext, subRace.Id,
            ModifierSourceType.Subrace, ct);
        
        _dbContext.Remove(subRace);
        await _dbContext.SaveChangesAsync(ct);
    }
}