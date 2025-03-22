namespace UDMT.Domain.Entity;

public class PlayerClassSavingThrow
{
    public int Id { get; set; }
    
    public int PlayerClassId { get; set; }
    
    public PlayerClass PlayerClass { get; set; }

    public AttributeType AttributeType { get; set; }
}