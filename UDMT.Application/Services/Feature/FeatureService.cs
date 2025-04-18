using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using NeerCore.Exceptions;
using UDMT.Application.DTO;
using UDMT.Application.Helpers;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Tech.Mod;
using Fea = UDMT.Domain.Entity.Tech.Fea.Feature;

namespace UDMT.Application.Services.Feature;

[Service]
public class FeatureService : IFeatureService
{
    private readonly IAppDbContext _dbContext;
    
    public FeatureService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ICollection<GetFeatureDto>> GetFeatureAsync(CancellationToken ct)
    {
        var features = await _dbContext.Set<Fea>()
            .ProjectToType<GetFeatureDto>()
            .ToArrayAsync(ct);

        if (features is null) throw new NotFoundException("There are no Modifiers so far");
        
        await ModifierRelationFactory.BindModifierRelationsAsync(_dbContext, features, 
            ModifierSourceType.Feature, ct);
        
        return features;
    }

    public async Task<FeatureDto> AddNewFeature(FeatureDto featureDto, CancellationToken ct)
    {
        var feature = featureDto.Adapt<Fea>();
        
        await _dbContext.Set<Fea>().AddAsync(feature, ct);
        
        if (featureDto.ModifierIds is not null)
        {
            await ModifierRelationFactory.SetModifierRelationAsync(_dbContext, featureDto.ModifierIds, 
                feature.Id, ModifierSourceType.Feature, ct);
        }
        
        await _dbContext.SaveChangesAsync(ct);

        return feature.Adapt<FeatureDto>();
    }

    public async Task<FeatureDto> UpdateFeatureAsync(int featureId, FeatureDto featureDto, CancellationToken ct)
    {
        var feature = await _dbContext.Set<Fea>()
            .FirstOrDefaultAsync(f => f.Id == featureId, ct);
        
        if (feature is null) throw new NotFoundException("No such Feature");

        featureDto.Adapt(feature);
        
        await ModifierRelationFactory.UpdateModifiersAsync(_dbContext, featureId,
            ModifierSourceType.Feature, featureDto.ModifierIds!, ct);
        
        await _dbContext.SaveChangesAsync(ct);

        return feature.Adapt<FeatureDto>(); 
    }

    public async Task DeleteFeatureAsync(int featureId, CancellationToken ct)
    {
        var feature = await _dbContext.Set<Fea>()
            .FirstOrDefaultAsync(m => m.Id == featureId, ct);
        
        if (feature is null) throw new NotFoundException($"There is no Modifiers with such Id: {featureId} ");

        await ModifierRelationFactory.RemoveModifierRelationsBySourceAsync(_dbContext, featureId,
            ModifierSourceType.Feature, ct);
        
        _dbContext.Remove(feature);
        await _dbContext.SaveChangesAsync(ct);
    }
}