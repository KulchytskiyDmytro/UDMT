using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Entity.Characters;

public class CharacterAttribute
{
    public int Id { get; set; }
    
    public int CharacterId { get; set; }
    
    public Character Character { get; set; }
    
    public AttributeType AttributeType { get; set; }
    
    public int Value { get; set; }
}