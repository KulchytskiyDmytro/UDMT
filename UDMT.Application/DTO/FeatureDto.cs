using UDMT.Domain.Entity.Tech.Fea;

namespace UDMT.Application.DTO;

public class FeatureDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public int? LevelRequirement { get; set; }
    
    public MechanicDto Mechanic { get; set; }
    
    public ICollection<int>? ModifierIds { get; set; }
}