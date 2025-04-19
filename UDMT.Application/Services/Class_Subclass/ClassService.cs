using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using NeerCore.Exceptions;
using UDMT.Application.DTO.Class_Subclass;
using UDMT.Application.Helpers;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.CharClass_Subclass;
using UDMT.Domain.Entity.Tech.Mod;

namespace UDMT.Application.Services.Class_Subclass;

[Service]
public class ClassService : IClassService
{
    private readonly IAppDbContext _dbContext;

    public ClassService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;

    }

    public async Task<ICollection<GetClassDto>> GetClassesAsync(CancellationToken ct)
    {
        var classes = await _dbContext.Set<CharClass>()
            .ProjectToType<GetClassDto>()
            .ToListAsync(ct);

        await ModifierRelationFactory.BindModifierRelationsAsync(_dbContext, classes, 
            ModifierSourceType.CharClass, ct);
        
        return classes.Adapt<ICollection<GetClassDto>>();
    }

    public async Task<ClassDto> AddNewClass(ClassDto classDto, CancellationToken ct)
    {
        var charClass = classDto.Adapt<CharClass>();

        await _dbContext.Set<CharClass>().AddAsync(charClass, ct);
        await _dbContext.SaveChangesAsync(ct);
        
        if (classDto.ModifierIds is not null)
        {
            await ModifierRelationFactory.SetModifierRelationAsync(_dbContext, classDto.ModifierIds, 
                charClass.Id, ModifierSourceType.CharClass, ct);
        }
        
        return charClass.Adapt<ClassDto>();
    }

    public async Task<ClassDto> UpdateClassAsync(int classId, ClassDto classDto, CancellationToken ct)
    {
        var charClass = await _dbContext.Set<CharClass>()
            .FirstOrDefaultAsync(b => b.Id == classId, ct);

        if (charClass is null) throw new NotFoundException("No such Class");
        
        await ModifierRelationFactory.UpdateModifiersAsync(_dbContext, classId,
            ModifierSourceType.CharClass, classDto.ModifierIds!, ct);
        
        await _dbContext.SaveChangesAsync(ct);
        
        return charClass.Adapt<ClassDto>(); 
    }

    public async Task DeleteClassAsync(int classId, CancellationToken ct)
    {
        var charClass = await _dbContext.Set<CharClass>()
            .FirstOrDefaultAsync(b => b.Id == classId, ct);
        
        if (charClass is null) throw new NotFoundException("No such Background");

        await ModifierRelationFactory.RemoveModifierRelationsBySourceAsync(_dbContext, classId,
            ModifierSourceType.CharClass, ct);
        
        _dbContext.Remove(charClass);
        await _dbContext.SaveChangesAsync(ct);
    }
}