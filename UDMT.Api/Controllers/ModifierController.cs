using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services.Modifier;

namespace UDMT.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModifierController : ControllerBase
{
    private readonly IModifierService _modifierService;
    
    public ModifierController(IModifierService charService)
    {
        _modifierService = charService;
    }
    
    [HttpPost("add")]
    public async Task<ModifierDto> CreateModifier([FromBody] ModifierDto modifierDto, CancellationToken ct)
    {
        return await _modifierService.AddNewModifier(modifierDto, ct);
    }

    [HttpGet("get")]
    public async Task<ICollection<ModifierDto>> GetAllModifiers(CancellationToken ct)
    {
        return await _modifierService.GetModifiersAsync(ct);
    }

    [HttpDelete("delete/{modifierId}")]
    public async Task DeleteModifier([FromRoute] int modifierId, CancellationToken ct)
    {
        await _modifierService.DeleteModifierAsync(modifierId, ct);
    }
}