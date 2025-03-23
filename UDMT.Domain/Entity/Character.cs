namespace UDMT.Domain.Entity;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RaceId { get; set; }
    public int CharacterClassId { get; set; }
    public int ProficencyBonus { get; set; }
    
    public Race Race { get; set; }
    public CharacterClass CharacterClass { get; set; }

    public ICollection<CharacterSavingThrow> SavingThrows { get; set; } = new List<CharacterSavingThrow>();
    
    public ICollection<CharacterAttribute> Attributes { get; set; } = new List<CharacterAttribute>();
    
    public ICollection<CharacterSkill> Skills { get; set; } = new List<CharacterSkill>();
}