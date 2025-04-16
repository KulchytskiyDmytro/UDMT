using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Entity.Char;

public class CharAttribute
{
    public int Id { get; set; }
    
    public AttributeType AttributeType { get; set; }
    
    public int BonusModifier { get; set; }
    
    public int? BonusOverride { get; set; }
    
    public int CharacterId { get; set; }
    
    public Character Character { get; set; }
}