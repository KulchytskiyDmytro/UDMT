using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;
using UDMT.Domain.Entity.Classes;

namespace UDMT.Application.Services.CharGenServices.Subclass;

[Service]
public class SubclassService : ISubclassService
{
    private readonly AppDbContext _context;

    public SubclassService(AppDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<List<SubclassDto>> GetSubclassAsync()
    {
        return await _context.CharSubclasses
            .ProjectToType<SubclassDto>()
            .ToListAsync();
    }

    public async Task AddNewSubclassAsync(SubclassDto subclassDto)
    {
        
        var subclass = new SubclassDto
        {
            Name = subclassDto.Name,
            Description = subclassDto.Description,
            IsHomebrew = subclassDto.IsHomebrew,
            GrantsMagic = subclassDto.GrantsMagic,
            CharClassId = subclassDto.CharClassId
        };

        if (subclass.GrantsMagic is true)
        {
            var temp = await _context.CharClasses.FirstOrDefaultAsync(
                cc => cc.Id == subclass.CharClassId);
            temp.HasMagic = subclass.GrantsMagic;
        }
        
        var result = subclass.Adapt<CharSubclass>();
        
        _context.CharSubclasses.Add(result);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSubclassAsync(SubclassDto subclassDto)
    {
        var subclass = await _context.CharSubclasses
            .Include(sc => sc.Features)
            .FirstOrDefaultAsync(sc => sc.Id == subclassDto.Id);
        
        if (subclass == null)
            throw new Exception($"Race Id={subclassDto.Id} не найден");
        
        if (subclass.GrantsMagic is true)
        {
            var temp = await _context.CharClasses.FirstOrDefaultAsync(
                cc => cc.Id == subclass.CharClassId);
            temp.HasMagic = subclass.GrantsMagic;
        }
        
        subclassDto.Adapt(subclass);
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSubclassAsync(int subclassId)
    {
        var subclass = await _context.CharSubclasses
            .FirstOrDefaultAsync(cs => cs.Id == subclassId);
        if (subclass != null) _context.CharSubclasses.Remove(subclass);
        await _context.SaveChangesAsync();
    }
}