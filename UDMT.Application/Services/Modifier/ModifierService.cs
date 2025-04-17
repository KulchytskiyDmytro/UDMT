using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using NeerCore.Exceptions;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
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
        
        await _dbContext.Set<Mod>().AddAsync(modifier, ct);
        await _dbContext.SaveChangesAsync(ct);

        return modifier.Adapt<ModifierDto>();
    }

    public Task<ModifierDto> UpdateModifierAsync(int bgId, ModifierDto modifierDto, CancellationToken ct)
    {
        throw new NotImplementedException();
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