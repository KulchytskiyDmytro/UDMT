namespace UDMT.Application.DTO;

public class CharacterDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int RaceId { get; set; }
    
    public int CharClassId { get; set; }
    
    public int? SubclassId { get; set; } 
    
    public int MaxHitPoints { get; set; }
    public int CurrentHitPoints { get; set; }
    
    public int ProficencyBonus { get; set; }
    
    public CharClassDto CharClass { get; set; } = null!;
    
    public ICollection<CharacterAttributeDto> CharacterAttributes { get; set; } = new List<CharacterAttributeDto>();
    
    public ICollection<CharacterSavingThrowDto> SavingThrows { get; set; } = new List<CharacterSavingThrowDto>();
    
}