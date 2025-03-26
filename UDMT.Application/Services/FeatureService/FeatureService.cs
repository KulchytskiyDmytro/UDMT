using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using UDMT.Application.DTO;
using UDMT.Application.Services.Validation;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Classes;

namespace UDMT.Application.Services.FeatureService;

[Service]
public class FeatureService : IFeatureService
{
    private readonly AppDbContext _context;
    private readonly IValidationService _validation;

    public FeatureService(
        AppDbContext context,
        IValidationService validationService)
    {
        _context = context;
        _validation = validationService;
    }

    public async Task<ICollection<FeatureDto>> GetAllFeatures()
    {
        var features = await _context.Features
            .Include(f => f.ClassMechanic)
            .ToListAsync();

        return features.Adapt<ICollection<FeatureDto>>();
    }

    public async Task<int> AddFeatureAsync(FeatureDto featureDto)
    {
        var feature = featureDto.Adapt<Feature>();
        
        await _validation.ValidateMechanicClassMatchAsync(featureDto.CharClassId, featureDto.CharSubclassId); 
        
        _context.Features.Add(feature);
        await _context.SaveChangesAsync();

        return feature.Id;
    }

    public async Task UpdateFeatureAsync(int featureId, FeatureDto featureDto)
    {
        var feature = await _context.Features
            .FirstOrDefaultAsync(cm => cm.Id == featureId);
        
        await _validation.ValidateMechanicClassMatchAsync(featureDto.CharClassId, featureDto.CharSubclassId);
        
        feature.Adapt<FeatureDto>();
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFeatureAsync(int featureId)
    {
        var feature = await _context.Features
            .FirstOrDefaultAsync(cm => cm.Id == featureId);
        if (feature != null) _context.Features.Remove(feature);
        await _context.SaveChangesAsync();
    }
}