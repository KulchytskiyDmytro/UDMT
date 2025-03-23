namespace UDMT.Application.DTO;

public class CharacterDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int RaceId { get; set; }
    
    public int CharacterClassId { get; set; }
    
    public int ProficencyBonus { get; set; }
    
    public ICollection<CharacterAttributeDto> CharacterAttributes { get; set; } = new List<CharacterAttributeDto>();
    
    public ICollection<SavingThrowDto> SavingThrowDtos { get; set; } = new List<SavingThrowDto>();
}