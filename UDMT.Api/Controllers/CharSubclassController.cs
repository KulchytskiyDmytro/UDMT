using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services.CharGenServices;
using UDMT.Application.Services.CharGenServices.Subclass;

namespace UDMT.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharSubclassController : ControllerBase
{
    private readonly ISubclassService _subclassService;
    
    public CharSubclassController(ISubclassService subclassService)
    {
        _subclassService = subclassService;
    }
        
    [HttpPost("add")]
    public async Task CreateSubclass([FromBody] SubclassDto subclassDto)
    {
        await _subclassService.AddNewSubclassAsync(subclassDto);
    }
    
    [HttpGet("get")]
    public async Task<ICollection<SubclassDto>> GetSubclasses()
    {
        return await _subclassService.GetSubclassAsync();
    }
    
    [HttpPut("update")]
    public async Task UpdateSeubclass([FromBody] SubclassDto subclassDto)
    {
        await _subclassService.UpdateSubclassAsync(subclassDto);
    }

    [HttpDelete("{subclassId}")]
    public async Task RemoveSubclass([FromRoute] int subclassId)
    {
        await _subclassService.DeleteSubclassAsync(subclassId);
    }
}