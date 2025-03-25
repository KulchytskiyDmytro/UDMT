using Microsoft.AspNetCore.Mvc;
using UDMT.Application.DTO;
using UDMT.Application.Services.CharGenServices;

namespace UDMT.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;
    
    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }
    
    [HttpPost("add")]
    public async Task CreateCharacter([FromBody] CharacterDto characterDto)
    {
        await _characterService.AddNewCharacter(characterDto);
    }

    [HttpGet("get")]
    public async Task<ICollection<CharacterDto>> GetCharacter()
    {
        return await _characterService.GetCharactersAsync();
    }

    [HttpPut("update")]
    public async Task UpdateCharacter([FromBody] CharacterDto characterDto)
    {
        await _characterService.UpdateCharacterAsync(characterDto);
    }

    [HttpDelete("{characterId}")]
    public async Task RemoveCharacter([FromRoute] int characterId)
    {
        await _characterService.DeleteCharacterAsync(characterId);
    }
    
}