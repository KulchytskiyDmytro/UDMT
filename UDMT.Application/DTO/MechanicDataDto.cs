using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.DTO;

public class MechanicDataDto
{
    public int? MaxUses { get; set; }
    public int? DurationInRounds { get; set; }
    
    public DamageFormulaDto? BonusDamage { get; set; }

    public ActivationType? ActivationType { get; set; }
    public RestType? RestType { get; set; }
    public MechanicCondition? Condition { get; set; }

    public TargetType? Target { get; set; }
    public List<AttributeType>? AddModifiers { get; set; }
    
    public int? GrantsSkillId { get; set; }

    public AttributeType? RelatedAttribute { get; set; }
    
}
