namespace UDMT.Domain.Entity;

public class CharacterAttribute
{
    public int Id { get; set; }
    
    public int PlayerId { get; set; }
    public Player Player { get; set; }
    
    public AttributeType AttributeType { get; set; }
    
    public int Value { get; set; }
}