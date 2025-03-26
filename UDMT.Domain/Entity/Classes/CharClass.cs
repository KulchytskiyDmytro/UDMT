using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Entity.Classes;

public class CharClass
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    
    public bool IsHomebrew { get; set; }
    
    public int ProficencyBonus { get; set; }
    
    public bool HasMagic { get; set; }
    
    public HpDieType HitDie { get; set; }
    
    public ICollection<CharClassSavingThrow>? SavingThrowProficiencies { get; set; } = new List<CharClassSavingThrow>();
    
    public ICollection<Feature>? Features { get; set; } = new List<Feature>();
    
    public ICollection<ClassSkill>? ClassSkills { get; set; } = new List<ClassSkill>();
    
    public ICollection<CharSubclass>? Subclasses{ get; set; } = new List<CharSubclass>();
}