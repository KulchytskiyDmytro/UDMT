using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Entity.Tech.Fea;

public class Mechanic
{
    public int Id { get; set; }
    
    public int FeatureId { get; set; }
    
    public Feature Feature { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public DiceType? DiceType { get; set; }
    
    public int? Value { get; set; }
}