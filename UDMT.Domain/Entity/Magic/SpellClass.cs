using UDMT.Domain.Entity.CharClass_Subclass;

namespace UDMT.Domain.Entity.Magic;

public class SpellClass
{
    public int Id { get; set; }
    
    public int SpellId { get; set; }
    public Spell Spell { get; set; }
    
    public int ClassId { get; set; }
    public CharClass CharClass { get; set; }
    
    public int SubclassId  { get; set; }
    public CharSubclass? CharSubclass { get; set; }
}