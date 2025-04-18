using UDMT.Domain.Entity.Shared;
using UDMT.Domain.Entity.Tech.Mod;

namespace UDMT.Application.DTO;

public class ModifierDto
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public ModifierType ModifierType { get; set; }
    
    public AttributeType AttributeType { get; set; }
    
    public int? Value { get; set; }

    public AdvantageType? AdvantageType { get; set; }
    
    public ProficiencyType ProficiencyType { get; set; }
    
    public int? SkillId { get; set; }
}