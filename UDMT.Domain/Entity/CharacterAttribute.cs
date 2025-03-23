namespace UDMT.Domain.Entity;

public class CharacterAttribute
{
    public int Id { get; set; }
    
    public int CharacterId { get; set; }
    
    public Character Character { get; set; }
    
    public AttributeType AttributeType { get; set; }
    
    public int Value { get; set; }
}