using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Entity.Classes;

public class CharClassSavingThrow
{
    public int Id { get; set; }
    
    public int CharClassId { get; set; }
    
    public CharClass CharClass { get; set; }

    public AttributeType AttributeType { get; set; }
}