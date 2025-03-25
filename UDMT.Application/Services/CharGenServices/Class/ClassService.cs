using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;

namespace UDMT.Application.Services.CharGenServices.Class;

[Service]
public class ClassService : IClassService
{
    private readonly AppDbContext _context; 
    
    public ClassService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<CharClassDto>> GetAllClassesAsync()
    {
        var classes = await _context.CharClasses
            .Include(st => st.SavingThrowProficiencies)
            .ToListAsync();

        return classes.Adapt<List<CharClassDto>>();
    }

    public async Task<int> AddClassAync(CharClassDto charClassDto)
    {
        var charClass = charClassDto.Adapt<CharClass>();
        
        if (charClassDto.SavingThrowProficiencies != null && charClassDto.SavingThrowProficiencies.Any())
        {
            charClass.SavingThrowProficiencies = charClassDto.SavingThrowProficiencies
                .Select(attr => new CharClassSavingThrow
                {
                    AttributeType = attr
                })
                .ToList();
        }
        else
        {
            charClass.SavingThrowProficiencies = new List<CharClassSavingThrow>();
        }
        
        _context.CharClasses.Add(charClass);
        await _context.SaveChangesAsync();
        return charClassDto.Id;
    }

    public async Task UpdateClassAsync(CharClassDto charClassDto)
    {
        var charClass = await _context.CharClasses
            .Where(cc => cc.Id == charClassDto.Id)
            .Include(cc => cc.SavingThrowProficiencies)
            .FirstOrDefaultAsync();

        charClassDto.Adapt(charClass);

        charClass.SavingThrowProficiencies = charClassDto.SavingThrowProficiencies
            .Select(attrEnum => new CharClassSavingThrow
            {
                AttributeType = attrEnum
            })
            .ToList();
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteClassAsync(int classId)
    {
        var charClass = await _context.CharClasses
            .FirstOrDefaultAsync(cc => cc.Id == classId);

        _context.Remove(charClass);
        await _context.SaveChangesAsync();
    }
}