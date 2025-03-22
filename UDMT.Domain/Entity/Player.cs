namespace UDMT.Domain.Entity;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RaceId { get; set; }
    public int PlayerClassId { get; set; }
    public int ProficencyBonus { get; set; }
    
    public Race Race { get; set; }
    public PlayerClass PlayerClass { get; set; }

    public ICollection<CharacterAttribute> Attributes { get; set; } = new List<CharacterAttribute>();
    
    public ICollection<CharacterSkill> Skills { get; set; } = new List<CharacterSkill>();
}