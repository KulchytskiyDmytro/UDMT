namespace UDMT.Application.DTO;

public class GetRacesDto : IModifierContainer
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }

    public bool IsHomebrew { get; set; }
    
    public ICollection<SubRaceDto>? SubRaces { get; set; }
    public ICollection<ModifierDto>? Modifiers { get; set; }
}