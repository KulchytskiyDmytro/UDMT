namespace UDMT.Domain.Entity.Race_Subrace;

public class Race
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsHomebrew { get; set; }
    
    public  ICollection<SubRace>? SubRaces { get; set; }
}