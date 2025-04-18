using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.DTO;

public class MechanicDto
{
    public int Id { get; set; }
    
    public int FeatureId { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public DiceType? DiceType { get; set; }
    
    public int? Value { get; set; }
}
