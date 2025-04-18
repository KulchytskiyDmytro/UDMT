using UDMT.Application.DTO;

namespace UDMT.Application.Services.Feature;

public interface IFeatureService
{
    Task<ICollection<GetFeatureDto>> GetFeatureAsync(CancellationToken ct);
    Task<FeatureDto> AddNewFeature(FeatureDto featureDto, CancellationToken ct);
    Task<FeatureDto> UpdateFeatureAsync(int featureId, FeatureDto featureDto, CancellationToken ct);
    Task DeleteFeatureAsync(int featureId, CancellationToken ct);
}
