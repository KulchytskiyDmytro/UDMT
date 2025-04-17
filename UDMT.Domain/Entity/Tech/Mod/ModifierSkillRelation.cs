namespace UDMT.Domain.Entity.Tech.Mod;

public class ModifierSkillRelation
{
    public int Id { get; set; }
    
    public int SkillId { get; set; }
    
    public Skill Skill { get; set; }
    
    public int ModifierId { get; set; }
    
    public Modifier Modifier { get; set; }
}