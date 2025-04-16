using UDMT.Domain.Entity.CharClass_Subclass;

namespace UDMT.Domain.Entity.Char;

public class CharClassLevel
{
    public int Id { get; set; }
    
    public int CharacterId { get; set; }
    public Character Character { get; set; }
    
    public int ClassId { get; set; }
    public CharClass CharClass { get; set; }
    
    public int Level { get; set; }
}