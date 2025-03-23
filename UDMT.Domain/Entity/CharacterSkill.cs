using System.ComponentModel.DataAnnotations;

namespace UDMT.Domain.Entity;

public class CharacterSkill
{
    [Key]
    public int Id { get; set; }
    
    public int CharacterId { get; set; }
    public Character Character { get; set; }

    public int SkillId { get; set; }
    public Skill Skill { get; set; }

    public bool? IsProficient { get; set; }
    public int? BonusOverride { get; set; }
}