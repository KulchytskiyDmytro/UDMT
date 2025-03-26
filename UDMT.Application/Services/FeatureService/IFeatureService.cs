using UDMT.Application.DTO;

namespace UDMT.Application.Services.FeatureService;

public interface IFeatureService
{
    Task<ICollection<FeatureDto>> GetAllFeatures();

    Task<int> AddFeatureAsync(FeatureDto featureDto);

    Task UpdateFeatureAsync(int featureId, FeatureDto featureDto);

    Task DeleteFeatureAsync(int featureId);
}