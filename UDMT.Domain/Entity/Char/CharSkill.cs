using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Entity.Char;

public class CharSkill
{
    public int Id { get; set; }
    
    public int SkillId { get; set; }
    
    public Skill Skill { get; set; }
    
    public ProficiencyType ProficiencyType { get; set; }
    
    public int BonusModifier { get; set; }
    
    public int? BonusOverride { get; set; }
    
    public int CharacterId { get; set; }
    
    public Character Character { get; set; }
}