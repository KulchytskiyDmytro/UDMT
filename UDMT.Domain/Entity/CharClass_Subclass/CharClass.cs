using UDMT.Domain.Entity.Back;
using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Entity.CharClass_Subclass;

public class CharClass
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public bool GrantsSpellcasting  { get; set; }
    
    public bool IsHomebrew { get; set; }
    
    public AttributeType? SpellcastingAbility  { get; set; }
    
    public HpDiceType HpDiceType { get; set; }
    
    public ICollection<CharSubclass>? Subclasses { get; set; }
    
    public ClassCastType? ClassCastType { get; set; }
    
    public ICollection<SpellcastingProgression>? SpellcastingProgression { get; set; }
}