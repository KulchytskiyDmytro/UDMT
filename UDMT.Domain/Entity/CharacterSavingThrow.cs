namespace UDMT.Domain.Entity;

public class CharacterSavingThrow
{
    public int Id { get; set; }
    
    public int CharacterId { get; set; }
    public Character Character { get; set; }
    
    public bool IsProficient { get; set; }
    public int BonusOverride { get; set; }
    
    public AttributeType AttributeType { get; set; }
}