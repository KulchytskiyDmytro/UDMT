using Mapster;
using Microsoft.EntityFrameworkCore;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Tech.Mod;

namespace UDMT.Application.Helpers;

public static class ModifierRelationFactory
{
    /// <summary>
    /// Set Modifier to Specific Entity
    /// </summary>
    public static async Task SetModifierRelationAsync(
        IAppDbContext dbContext, 
        IEnumerable<int> modifierIds, 
        int sourceId, 
        ModifierSourceType sourceType, 
        CancellationToken ct)
    {
        foreach (var modifierId in modifierIds)
        {
            var relation = new ModifierRelation
            {
                ModifierId = modifierId,
                SourceId = sourceId,
                SourceType = sourceType
            };
            await dbContext.Set<ModifierRelation>().AddAsync(relation, ct);
        }
        
        await dbContext.SaveChangesAsync(ct);
    }
    
    /// <summary>
    /// Deletes Relations Table when Source is deleted
    /// </summary>
    public static async Task RemoveModifierRelationsBySourceAsync(
        IAppDbContext dbContext,
        int sourceId,
        ModifierSourceType sourceType,
        CancellationToken ct)
    {
        var relations = await dbContext.Set<ModifierRelation>()
            .Where(r => r.SourceId == sourceId && r.SourceType == sourceType)
            .ToListAsync(ct);

        dbContext.RemoveRange(relations);
    }

    /// <summary>
    /// Gets Modifiers and adds them to EntitiesDto
    /// </summary>
    public static async Task BindModifierRelationsAsync<TDto>(
        IAppDbContext dbContext,
        ICollection<TDto> dtos,
        ModifierSourceType sourceType,
        CancellationToken ct)
    where TDto : class, IModifierContainer
    {
        var modifierRelations = await dbContext.Set<ModifierRelation>()
            .Where(mr => mr.SourceType == sourceType)
            .ToListAsync(ct);
        
        var modifierIds = modifierRelations.Select(r => r.ModifierId)
            .Distinct().ToList();
        
        var modifiers = await dbContext.Set<Modifier>()
            .Where(m => modifierIds.Contains(m.Id))
            .ProjectToType<ModifierDto>()
            .ToListAsync(ct);
        
        foreach (var dto in dtos)
        {
            var relatedIds = modifierRelations
                .Where(r => r.SourceId == dto.Id)
                .Select(r => r.ModifierId)
                .ToList();
            
            dto.Modifiers  = modifiers
                .Where(m => relatedIds.Contains(m.Id))
                .ToList();
        }
    }

    /// <summary>
    /// Get Modifiers by Entity
    /// </summary>
    public static async Task<ICollection<ModifierDto>> GetModifiersBySourceIdAsync(
        IAppDbContext dbContext,
        int sourceId, 
        ModifierSourceType sourceType,
        CancellationToken ct
    )
    {
        var modifierRelations = await dbContext.Set<ModifierRelation>()
            .Where(mr => mr.SourceId == sourceId && mr.SourceType == sourceType)
            .ToListAsync(ct);
        
        var modifierIds = modifierRelations
            .Select(r => r.ModifierId)
            .ToList();
        
        var modifiers = await dbContext.Set<Modifier>()
            .Where(m => modifierIds.Contains(m.Id))
            .ProjectToType<ModifierDto>()
            .ToListAsync(ct);

        return modifiers;
    }

    /// <summary>
    /// Update Modifiers to Entities
    /// </summary>
    public static async Task UpdateModifiersAsync(
        IAppDbContext dbContext,
        int sourceId,
        ModifierSourceType sourceType,
        ICollection<int> newModifierIds,
        CancellationToken ct)
    {
        var modifierRelations = await dbContext.Set<ModifierRelation>()
            .Where(mr => mr.SourceId == sourceId && mr.SourceType == sourceType)
            .ToListAsync(ct);
        
        var modifierIds = modifierRelations
            .Select(r => r.ModifierId)
            .ToList();
        
        var newModifiers = newModifierIds.OrderBy(x => x).ToList();
        var oldModifiers = modifierIds.OrderBy(x => x).ToList();

        if (!newModifiers.SequenceEqual(oldModifiers))
        {
            await SetAndDeleteModifiersAsync(
                dbContext, sourceId, sourceType, newModifiers, oldModifiers, ct);
        }
    }
    
    private static async Task SetAndDeleteModifiersAsync(
        IAppDbContext dbContext,
        int sourceId,
        ModifierSourceType sourceType,
        ICollection<int> newModifierIds,
        ICollection<int> oldModifierIds,
        CancellationToken ct)
    {
        var toRemove = oldModifierIds.Except(newModifierIds).ToList();
        var toAdd = newModifierIds.Except(oldModifierIds).ToList();

        if (toRemove.Any())
        {
            var relationsToRemove = await dbContext.Set<ModifierRelation>()
                .Where(mr => mr.SourceId == sourceId &&
                             mr.SourceType == sourceType &&
                             toRemove.Contains(mr.ModifierId))
                .ToListAsync(ct);

            dbContext.RemoveRange(relationsToRemove);
        }
        
        if (toAdd.Any())
        {
            var relationsToAdd = toAdd.Select(modifierId => new ModifierRelation
            {
                ModifierId = modifierId,
                SourceId = sourceId,
                SourceType = sourceType
            });

            await dbContext.AddRangeAsync(relationsToAdd, ct);
        }
    }
}