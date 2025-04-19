using UDMT.Domain.Entity.Back;

namespace UDMT.Application.DTO.Class_Subclass;

public class SubclassDto
{
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public bool GrantsSpellcasting  { get; set; }
    
    public bool IsHomebrew { get; set; }
    
    public int CharClassId { get; set; }
    
    public ClassCastType? CastTypeOverride  { get; set; }
}