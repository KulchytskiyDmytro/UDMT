namespace UDMT.Domain.Entity.Tech.Fea;

public class Feature
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public int? LevelRequirement { get; set; }
    
    public Mechanic Mechanic { get; set; }
}