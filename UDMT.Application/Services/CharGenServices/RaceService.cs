using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;

namespace UDMT.Application.Services.CharGenServices;

[Service]
public class RaceService : IRaceService
{
    private readonly AppDbContext _context;
    private IRaceService _raceService;

    public RaceService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<RaceDto>> GetRacesAsync()
    {
        return await _context.Races
            .ProjectToType<RaceDto>().ToListAsync();
    }

    public async Task AddNewRace(RaceDto raceDto)
    {
        var race = raceDto.Adapt<Race>();

        if (!race.IsRequireSubrace)
            race.RaceRelations = new List<RaceRelation>();
        else
        {
            race.RaceRelations = null;
        }
        _context.Races.Add(race);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRaceAsync(RaceDto raceDto)
    {
        var race = await _context.Races
            .Include(r => r.AttributeBonuses)
            .Include(r => r.RaceRelations)
            .FirstOrDefaultAsync(r => r.Id == raceDto.Id);

        if (race == null)
            throw new Exception($"Race Id={raceDto.Id} не найден");

        foreach (var relation in raceDto.RaceRelations ?? Enumerable.Empty<RaceRelationDto>())
        {
            // Обнуляем "нулевые" Id из JSON/UI
            if (relation.SubraceId == 0)
                relation.SubraceId = null;
        }
        
        raceDto.Adapt(race); // Mapster: переносим все значения из DTO в сущность

        await _context.SaveChangesAsync();
    }

    public async Task DeleteRaceAsync(int raceId)
    {
        var race = await _context.Races.FirstOrDefaultAsync(p => p.Id == raceId);
        if (race != null) _context.Races.Remove(race);
        await _context.SaveChangesAsync();
    }
}