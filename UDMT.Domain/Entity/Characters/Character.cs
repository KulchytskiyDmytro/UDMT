using UDMT.Domain.Entity.Classes;
using UDMT.Domain.Entity.Races;

namespace UDMT.Domain.Entity.Characters;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public int RaceId { get; set; }
    public int CharClassId { get; set; }
    
    public int? SubclassId { get; set; } 
    
    public int MaxHitPoints { get; set; }
    public int CurrentHitPoints { get; set; }
    
    public Race Race { get; set; }
    public CharClass CharClass { get; set; }
    public CharSubclass? Subclass { get; set; }
    
    public ICollection<CharacterSavingThrow> SavingThrows { get; set; } = new List<CharacterSavingThrow>();
    
    public ICollection<CharacterAttribute> Attributes { get; set; } = new List<CharacterAttribute>();
    
    public ICollection<CharacterSkill> Skills { get; set; } = new List<CharacterSkill>();
}