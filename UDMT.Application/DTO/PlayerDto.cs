namespace UDMT.Application.DTO;

public class PlayerDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int RaceId { get; set; }
    
    public int PlayerClassId { get; set; }
    
    public int ProficencyBonus { get; set; }
    
    public ICollection<CharacterAttributeDto> CharacterAttributes { get; set; } = new List<CharacterAttributeDto>();
    
    public ICollection<SavingThrowDto> SavingThrowDtos { get; set; } = new List<SavingThrowDto>();
}