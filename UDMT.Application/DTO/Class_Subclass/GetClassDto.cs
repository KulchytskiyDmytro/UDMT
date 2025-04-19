using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.DTO.Class_Subclass;

public class GetClassDto : IModifierContainer
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public bool GrantsSpellcasting  { get; set; }
    
    public bool IsHomebrew { get; set; }
    
    public AttributeType? SpellcastingAbility  { get; set; }
    
    public HpDiceType HpDiceType { get; set; }
    
    public ICollection<ModifierDto>? Modifiers { get; set; }
}