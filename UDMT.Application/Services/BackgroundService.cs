using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using NeerCore.Exceptions;
using UDMT.Application.DTO;
using UDMT.Application.Helpers;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Back;
using UDMT.Domain.Entity.Tech.Mod;

namespace UDMT.Application.Services;

[Service]
public class BackgroundService : IBackgroundService
{
    private readonly IAppDbContext _dbContext;

    public BackgroundService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ICollection<GetBackgroundsDto>> GetBackgroundAsync(CancellationToken ct)
    {
        var backgrounds = await _dbContext.Set<Background>()
            .ProjectToType<GetBackgroundsDto>()
            .ToArrayAsync(ct);

        await ModifierRelationFactory.BindModifierRelationsAsync(_dbContext, backgrounds, 
            ModifierSourceType.Background, ct);
        
        return backgrounds;
    }

    public async Task<BackgroundDto> AddNewBackground(BackgroundDto backgroundDto, CancellationToken ct)
    {
        var background = backgroundDto.Adapt<Background>();
        
        await _dbContext.Set<Background>().AddAsync(background, ct);
        await _dbContext.SaveChangesAsync(ct);

        if (backgroundDto.ModifierIds is not null)
        {
            await ModifierRelationFactory.SetModifierRelationAsync(_dbContext, backgroundDto.ModifierIds, 
                background.Id, ModifierSourceType.Background, ct);
        }

        return background.Adapt<BackgroundDto>();
    }

    public async Task<BackgroundDto> UpdateBackgroundAsync(int bgId, BackgroundDto backgroundDto, CancellationToken ct)
    {
        var background = await _dbContext.Set<Background>()
            .Where(b => b.Id == bgId)
            .FirstOrDefaultAsync(ct);

        if (background is null) throw new NotFoundException("No such Background");
        
        var updated = backgroundDto.Adapt(background);

        await _dbContext.SaveChangesAsync(ct);
        
        if (backgroundDto.ModifierIds is not null)
        {
            await ModifierRelationFactory.SetModifierRelationAsync(_dbContext, backgroundDto.ModifierIds, 
                background.Id, ModifierSourceType.Background, ct);
        }

        return updated.Adapt<BackgroundDto>(); 
    }

    public async Task DeleteBackgroundAsync(int bgId, CancellationToken ct)
    {
        var background = await _dbContext.Set<Background>()
            .FirstOrDefaultAsync(b => b.Id == bgId, ct);
        
        if (background is null) throw new NotFoundException("No such Background");

        await ModifierRelationFactory.RemoveModifierRelationsAsync(_dbContext, background.Id,
            ModifierSourceType.Background, ct);
        
        _dbContext.Remove(background);
        await _dbContext.SaveChangesAsync(ct);
    }
}