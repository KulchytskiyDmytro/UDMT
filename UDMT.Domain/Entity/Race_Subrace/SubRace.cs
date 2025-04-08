namespace UDMT.Domain.Entity.Race_Subrace;

public class SubRace
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsHomebrew { get; set; }
    
    public Guid RaceId { get; set; }
    
    public Race_Subrace.Race Race { get; set; }
}