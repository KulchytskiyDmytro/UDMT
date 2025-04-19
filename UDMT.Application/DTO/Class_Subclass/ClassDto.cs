using UDMT.Domain.Entity.Back;
using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.DTO.Class_Subclass;

public class ClassDto
{
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public bool GrantsSpellcasting  { get; set; }
    
    public bool IsHomebrew { get; set; }
    
    public AttributeType? SpellcastingAbility  { get; set; }
    
    public HpDiceType HpDiceType { get; set; }
    
    public ICollection<SubclassDto>? Subclasses { get; set; }
    
    public ClassCastType? ClassCastType { get; set; }
    
    public ICollection<SpellcastingProgressionDto>? SpellcastingProgression { get; set; }
    
    public ICollection<int>? ModifierIds { get; set; }
}