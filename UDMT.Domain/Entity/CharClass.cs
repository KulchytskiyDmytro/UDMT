namespace UDMT.Domain.Entity;

public class CharClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public int ProficencyBonus { get; set; }

    public ICollection<CharClassSavingThrow>? SavingThrowProficiencies { get; set; } = new List<CharClassSavingThrow>();
    public ICollection<Feature>? Features { get; set; } = new List<Feature>();
    public ICollection<ClassSkill>? ClassSkills { get; set; } = new List<ClassSkill>();
}