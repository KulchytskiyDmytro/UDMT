namespace UDMT.Application.DTO;

public class RaceDto
{
    public required string Name { get; set; }
    public string Description { get; set; }

    public bool IsHomebrew { get; set; }
    
    public ICollection<SubRaceDto>? SubRaces { get; set; }
    
    public ICollection<int>? ModifierIds { get; set; }
}