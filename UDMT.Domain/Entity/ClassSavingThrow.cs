namespace UDMT.Domain.Entity;

public class ClassSavingThrow
{
    public int Id { get; set; }
    
    public int CharacterClassId { get; set; }
    
    public CharacterClass CharacterClass { get; set; }

    public AttributeType AttributeType { get; set; }
}