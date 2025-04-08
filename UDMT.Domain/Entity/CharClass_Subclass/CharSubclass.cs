using UDMT.Domain.Entity.Back;

namespace UDMT.Domain.Entity.CharClass_Subclass;

public class CharSubclass
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public bool GrantsSpellcasting  { get; set; }
    
    public bool IsHomebrew { get; set; }
    
    public Guid CharClassId { get; set; }
    
    public CharClass CharClass { get; set; }
    
    public ClassCastType? CastTypeOverride  { get; set; }
}