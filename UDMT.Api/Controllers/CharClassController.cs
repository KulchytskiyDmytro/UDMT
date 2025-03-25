using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services.CharGenServices.Class;

namespace UDMT.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharClassController : ControllerBase
{
    private readonly IClassService _classService;
    
    public CharClassController(IClassService classService)
    {
        _classService = classService;
    }
    
    [HttpPost("add")]
    public async Task CreateCharClass([FromBody] CharClassDto charClassDto)
    {
        await _classService.AddClassAync(charClassDto);
    }

    [HttpGet("get")]
    public async Task<ICollection<CharClassDto>> GetCharClasses()
    {
        return await _classService.GetAllClassesAsync();
    }
    
    [HttpPut("update")]
    public async Task UpdateCharClass([FromBody] CharClassDto charClassDto)
    {
        await _classService.UpdateClassAsync(charClassDto);
    }

    [HttpDelete("{charClassId}")]
    public async Task RemoveCharClass([FromRoute] int charClassId)
    {
        await _classService.DeleteClassAsync(charClassId);
    }
}