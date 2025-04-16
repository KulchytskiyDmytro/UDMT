using Microsoft.EntityFrameworkCore;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Tech.Mod;

namespace UDMT.Application.Helpers;

public static class ModifierRelationFactory
{
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
}