using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO.Class_Subclass;
using UDMT.Application.Services.Class_Subclass;

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
    public async Task CreateClass([FromBody] ClassDto dto, CancellationToken ct)
    {
        await _classService.AddNewClass(dto, ct);
    }

    [HttpGet("get")]
    public async Task<ICollection<GetClassDto>> GetClass(CancellationToken ct)
    {
        return await _classService.GetClassesAsync(ct);
    }

    [HttpPut("update/{classId}")]
    public async Task<ClassDto> UpdateClass([FromRoute] int classId, 
        [FromBody] ClassDto dto, CancellationToken ct)
    {
        return await _classService.UpdateClassAsync(classId, dto, ct);
    }
    
    [HttpDelete("delete/{classId}")]
    public async Task DeleteClass([FromRoute] int classId, CancellationToken ct)
    {
        await _classService.DeleteClassAsync(classId, ct);
    }
}