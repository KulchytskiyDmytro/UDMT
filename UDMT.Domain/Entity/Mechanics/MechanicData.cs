using UDMT.Domain.Entity.Classes;
using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Entity.Mechanics;

public class MechanicData
{
    public int? MaxUses { get; set; }
    public int? DurationInRounds { get; set; }
    public DamageFormula? BonusDamage { get; set; }

    public ActivationType? ActivationType { get; set; }  
    public RestType? RestType { get; set; }              
    public MechanicCondition? Condition { get; set; }    

    public TargetType? Target { get; set; }              
    public List<AttributeType>? AddModifiers { get; set; }  

    public int? GrantsSkillId { get; set; }
    public ClassSkill? GrantsSkill { get; set; }

    public AttributeType? RelatedAttribute { get; set; }
}
