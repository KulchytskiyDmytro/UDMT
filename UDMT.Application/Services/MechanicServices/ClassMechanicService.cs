using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using UDMT.Application.DTO;
using UDMT.Application.Services.Validation;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;
using UDMT.Domain.Entity.Classes;

namespace UDMT.Application.Services.MechanicServices;

[Service]
public class ClassMechanicService : IClassMechanicService
{
    private readonly AppDbContext _context;

    public ClassMechanicService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<ClassMechanicDto>> GetAllClassMechanicsAsync()
    {
        var classMechanics = await _context.ClassMechanics
            .Include(cm => cm.Data)
            .ToListAsync();
        
        return classMechanics.Adapt<ICollection<ClassMechanicDto>>();
    }
    
    public async Task<int> AddClassMechanicAsync(ClassMechanicDto classMechanicDto)
    {
        var classMechanic = classMechanicDto.Adapt<ClassMechanic>();
        
        _context.ClassMechanics.Add(classMechanic);
        await _context.SaveChangesAsync();

        return classMechanic.Id;
    }

    public async Task UpdateClassMechanicAsync(int classMechanicId, ClassMechanicDto classMechanicDto)
    {
        var classMechanic = await _context.ClassMechanics
            .FirstOrDefaultAsync(cm => cm.Id == classMechanicId);
        
        classMechanicDto.Adapt(classMechanic);
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteClassMechanicAsync(int classMechanicId)
    {
        var classMechanic = await _context.ClassMechanics
            .FirstOrDefaultAsync(cm => cm.Id == classMechanicId);
        if (classMechanic != null) _context.ClassMechanics.Remove(classMechanic);
        await _context.SaveChangesAsync();
    }
}