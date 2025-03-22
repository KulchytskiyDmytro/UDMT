using Mapster;
using Microsoft.EntityFrameworkCore;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;

namespace UDMT.Application.Services;

public class SubraceService : ISubraceService
{
    private readonly AppDbContext _context;
    private IRaceService _raceService;

    public SubraceService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SubraceDto>> GetSubRacesAsync()
    {
        return await _context.RaceRelations
            .Where(r => r.Subrace != null)
            .Select(r => new SubraceDto
            {
                Id = r.Subrace.Id,
                Name = r.Subrace.Name,
                Description = r.Subrace.Description,
                IsHomebrew = r.Subrace.IsHomebrew,
                ParentRaceId = r.RaceId,
                AttributeBonuses = r.Subrace.AttributeBonuses
                    .Select(b => new RaceAttributeBonusDto
                    {
                        Id = b.Id,
                        AttributeType = b.AttributeType,
                        Value = b.Value,
                        RaceId = b.RaceId
                    }).ToList()
            })
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