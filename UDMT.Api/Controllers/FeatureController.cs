using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services.Feature;

namespace UDMT.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeatureController : ControllerBase
{
    private readonly IFeatureService _featureService;
    
    public FeatureController(IFeatureService featureService)
    {
        _featureService = featureService;
    }
    
    [HttpPost("add")]
    public async Task<FeatureDto> CreateFeature([FromBody] FeatureDto featureDto, CancellationToken ct)
    {
        return await _featureService.AddNewFeature(featureDto, ct);
    }

    [HttpGet("get")]
    public async Task<ICollection<GetFeatureDto>> GetAllFeatures(CancellationToken ct)
    {
        return await _featureService.GetFeatureAsync(ct);
    }

    [HttpDelete("delete/{featureId}")]
    public async Task DeleteFeature([FromRoute] int featureId, CancellationToken ct)
    {
        await _featureService.DeleteFeatureAsync(featureId, ct);
    }
}