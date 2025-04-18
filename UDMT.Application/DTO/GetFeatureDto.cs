namespace UDMT.Application.DTO;

public class GetFeatureDto : IModifierContainer
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public int? LevelRequirement { get; set; }
    
    public MechanicDto Mechanic { get; set; }
    
    public ICollection<ModifierDto>? Modifiers { get; set; }
}