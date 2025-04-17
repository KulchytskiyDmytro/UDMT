using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services;

namespace UDMT.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharController : ControllerBase
{
    private readonly ICharService _charService;
    
    public CharController(ICharService charService)
    {
        _charService = charService;
    }
    
    [HttpPost("add")]
    public async Task CreateCharClass([FromBody] CharDto charDto, CancellationToken ct)
    {
        await _charService.CreateChar(charDto, ct);
    }

    [HttpGet("get/{charId}")]
    public async Task<CharDto> GetCharById([FromRoute] int charId, CancellationToken ct)
    {
        return await _charService.GetChar(charId, ct);
    }
}