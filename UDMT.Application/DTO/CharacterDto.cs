using UDMT.Domain.Entity;

namespace UDMT.Application.DTO;

public class CharacterDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int RaceId { get; set; }
    
    public int CharClassId { get; set; }
    
    public int ProficencyBonus { get; set; }
    
    public ICollection<CharacterAttributeDto> CharacterAttributes { get; set; } = new List<CharacterAttributeDto>();
    
    public ICollection<CharacterSavingThrowDto> SavingThrowDtos { get; set; } = new List<CharacterSavingThrowDto>();
}