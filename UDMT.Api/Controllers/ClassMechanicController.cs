using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services.MechanicServices;

namespace UDMT.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassMechanicController : ControllerBase
{
    private readonly IClassMechanicService _classMechanicService;

    public ClassMechanicController(IClassMechanicService classMechanicService)
    {
        _classMechanicService = classMechanicService;
    }
    
    [HttpPost("add")]
    public async Task CreateClassMechanic([FromBody] ClassMechanicDto classMechanicDto)
    {
        await _classMechanicService.AddClassMechanicAsync(classMechanicDto);
    }
    
    [HttpGet("get")]
    public async Task<ICollection<ClassMechanicDto>> GetAllMechanicsById()
    {
        return await _classMechanicService.GetAllClassMechanicsAsync();
    }
    
    
    [HttpPut("{mechanicId}")]
    public async Task UpdateClassMechanic([FromRoute] int mechanicId,[FromBody]  ClassMechanicDto classMechanicDto)
    {
        await _classMechanicService.UpdateClassMechanicAsync(mechanicId, classMechanicDto);
    }

    [HttpDelete("{classMechanicId}")]
    public async Task RemoveClassMechanic([FromRoute] int classMechanicId)
    {
        await _classMechanicService.DeleteClassMechanicAsync(classMechanicId);
    }
}