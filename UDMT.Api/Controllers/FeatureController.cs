using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services.FeatureService;

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
    public async Task CreateClassMechanic([FromBody] FeatureDto featureDto)
    {
        await _featureService.AddFeatureAsync(featureDto);
    }
    
    [HttpGet("get")]
    public async Task<ICollection<FeatureDto>> GetAllMechanicsById()
    {
        return await _featureService.GetAllFeatures();
    }
    
    
    [HttpPut("update-/{featureId}")]
    public async Task UpdateClassMechanic([FromRoute] int featureId,[FromBody]  FeatureDto featureDto)
    {
        await _featureService.UpdateFeatureAsync(featureId, featureDto);
    }

    [HttpDelete("remove-/{featureId}")]
    public async Task RemoveClassMechanic([FromRoute] int featureId)
    {
        await _featureService.DeleteFeatureAsync(featureId);
    }
}