namespace UDMT.Domain.Entity.Race_Subrace;

public class SubRace
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsHomebrew { get; set; }
    
    public int RaceId { get; set; }
    
    public Race Race { get; set; }
}