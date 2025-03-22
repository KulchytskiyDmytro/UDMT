using System.ComponentModel.DataAnnotations;

namespace UDMT.Domain.Entity;

public class CharacterSkill
{
    [Key]
    public int Id { get; set; }
    
    public int PlayerId { get; set; }
    public Player Player { get; set; }

    public int SkillId { get; set; }
    public Skill Skill { get; set; }

    public bool? IsProficient { get; set; }
    public int? BonusOverride { get; set; }
}