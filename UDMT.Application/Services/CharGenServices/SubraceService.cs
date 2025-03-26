using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;
using UDMT.Domain.Entity.Races;

namespace UDMT.Application.Services.CharGenServices;

[Service]
public class SubraceService : ISubraceService
{
    private readonly AppDbContext _context;

    public SubraceService(AppDbContext context)
    {
        _context = context;
    }
    
    // TODO: Workout problem with DTO in Swagger
    public async Task<List<SubraceDto>> GetSubRacesAsync()
    {
        return await _context.RaceRelations
            .Where(r => r.Subrace != null)
            .ProjectToType<SubraceDto>()
            .ToListAsync();
    }

    public async Task AddNewSubRaceAsync(SubraceDto subraceDto)
    {
        var subrace = subraceDto.Adapt<Race>();
        
        var relation = new RaceRelation
        {
            RaceId = subraceDto.ParentRaceId, // ParentRaceId не хранится в бд
            Subrace = subrace // EF сам установит SubraceId после вставки
        };
        
        _context.RaceRelations.Add(relation);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSubRaceAsync(SubraceDto raceRelationDto)
    {
        var subrace = await _context.RaceRelations
            .Include(cr => cr.Subrace)
            .Where(sr => sr != null)
            .FirstOrDefaultAsync(sr => sr.Id == raceRelationDto.Id);
        
        if (subrace == null)
            throw new Exception($"Race Id={raceRelationDto.Id} не найден");

        raceRelationDto.Adapt(subrace);
        
        await _context.SaveChangesAsync();

    }

    public async Task DeleteSubRaceAsync(int subraceId)
    {
        var subrace = await _context.RaceRelations.FirstOrDefaultAsync(sr => sr.SubraceId == subraceId);
        if (subrace != null) _context.RaceRelations.Remove(subrace);
        await _context.SaveChangesAsync();
    }
}