using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using NeerCore.Exceptions;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;
using UDMT.Domain.Entity.Tech.Mod;
using Mod = UDMT.Domain.Entity.Tech.Mod.Modifier;

namespace UDMT.Application.Services.Modifier;

[Service]
public class ModifierService : IModifierService
{
    private readonly IAppDbContext _dbContext;
    
    public ModifierService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<ModifierDto>> GetModifiersAsync(CancellationToken ct)
    {
        var modifiers = await _dbContext.Set<Mod>()
            .ProjectToType<ModifierDto>()
            .ToArrayAsync(ct);

        if (modifiers is null) throw new NotFoundException("There are no Modifiers so far");
        
        return modifiers;
    }

    public async Task<ModifierDto> AddNewModifier(ModifierDto modifierDto, CancellationToken ct)
    {
        var modifier = modifierDto.Adapt<Mod>();

        // TODO: Don't forget about that when it comes to Skill Service
        // Yes it is hardcode
        if (modifierDto.SkillId.HasValue)
        {
            var skillExists = await _dbContext.Set<Skill>()
                .AnyAsync(s => s.Id == modifierDto.SkillId.Value, ct);

            if (!skillExists)
                throw new NotFoundException($"Skill with Id {modifierDto.SkillId.Value} does not exist");

            var skillRelation = new ModifierSkillRelation
            {
                ModifierId = modifier.Id,
                SkillId = modifierDto.SkillId.Value
            };

            await _dbContext.Set<ModifierSkillRelation>().AddAsync(skillRelation, ct);
            await _dbContext.SaveChangesAsync(ct);
        }
                
        await _dbContext.Set<Mod>().AddAsync(modifier, ct);
        await _dbContext.SaveChangesAsync(ct);
        
        return modifier.Adapt<ModifierDto>();
    }

    public async Task<ModifierDto> UpdateModifierAsync(int modifierId, ModifierDto modifierDto, CancellationToken ct)
    {
        var modifier = await _dbContext.Set<Mod>()
            .FirstOrDefaultAsync(m => m.Id == modifierId, ct);
        
        if (modifier is null) throw new NotFoundException("No such Modifier");

        modifierDto.Adapt(modifier);
        
        // And even that is also 
        var existingSkillRelation = await _dbContext.Set<ModifierSkillRelation>()
            .FirstOrDefaultAsync(r => r.ModifierId == modifierId, ct);
        
        if (modifierDto.SkillId is not null)
        {
            if (existingSkillRelation is null)
            {
                var newRelation = new ModifierSkillRelation
                {
                    ModifierId = modifierId,
                    SkillId = modifierDto.SkillId.Value
                };
                await _dbContext.Set<ModifierSkillRelation>().AddAsync(newRelation, ct);
            }
            else if (existingSkillRelation.SkillId != modifierDto.SkillId)
            {
                existingSkillRelation.SkillId = modifierDto.SkillId.Value;
            }
        }
        else if (existingSkillRelation is not null)
        {
            _dbContext.Remove(existingSkillRelation);
        }
        
        await _dbContext.SaveChangesAsync(ct);
        
        return modifier.Adapt<ModifierDto>();
    }

    public async Task DeleteModifierAsync(int modifierId, CancellationToken ct)
    {
        var modifier = await _dbContext.Set<Mod>()
            .FirstOrDefaultAsync(m => m.Id == modifierId, ct);
        
        if (modifier is null) throw new NotFoundException($"There is no Modifiers with such Id: {modifierId} ");

        _dbContext.Remove(modifier);
        await _dbContext.SaveChangesAsync(ct);
    }
}