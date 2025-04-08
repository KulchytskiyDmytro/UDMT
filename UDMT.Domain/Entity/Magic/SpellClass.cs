using UDMT.Domain.Entity.CharClass_Subclass;

namespace UDMT.Domain.Entity.Magic;

public class SpellClass
{
    public int Id { get; set; }
    
    public Guid SpellId { get; set; }
    public Spell Spell { get; set; }
    
    public Guid ClassId { get; set; }
    public CharClass CharClass { get; set; }
    
    public Guid SubclassId  { get; set; }
    public CharSubclass? CharSubclass { get; set; }
}