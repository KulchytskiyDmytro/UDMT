using Mapster;
using Microsoft.EntityFrameworkCore;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Tech.Mod;

namespace UDMT.Application.Helpers;

public static class ModifierRelationFactory
{
    /// <summary>
    /// Set/Updates Modifier to Specific Entity
    /// </summary>
    public static async Task SetModifierRelationAsync(
        IAppDbContext dbContext, 
        IEnumerable<int> modifierIds, 
        int sourceId, 
        ModifierSourceType sourceType, 
        CancellationToken ct)
    {
        var existingModifierIds = await dbContext.Set<ModifierRelation>()
            .Where(r => r.SourceId == sourceId && r.SourceType == sourceType)
            .Select(r => r.ModifierId)
            .ToListAsync(ct);
        
        foreach (var modifierId in modifierIds)
        {
            if (!existingModifierIds.Contains(modifierId))
            {
                var relation = new ModifierRelation
                {
                    ModifierId = modifierId,
                    SourceId = sourceId,
                    SourceType = sourceType
                };

                await dbContext.Set<ModifierRelation>().AddAsync(relation, ct);
            }
        }

        await dbContext.SaveChangesAsync(ct);
    }
    
    /// <summary>
    /// Deletes Relations Table when Source is deleted
    /// </summary>
    public static async Task RemoveModifierRelationsAsync(
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
    /// Binds Modifiers to Entities
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
}