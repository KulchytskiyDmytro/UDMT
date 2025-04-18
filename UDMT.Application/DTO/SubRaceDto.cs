namespace UDMT.Application.DTO;

public class SubRaceDto
{
    public string Name { get; set; }
    public string Description { get; set; }

    public bool IsHomebrew { get; set; }
    
    public ICollection<int>? ModifierIds { get; set; }
}