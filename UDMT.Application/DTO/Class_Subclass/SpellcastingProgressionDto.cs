using UDMT.Domain.Entity.Magic;

namespace UDMT.Application.DTO.Class_Subclass;

public class SpellcastingProgressionDto
{
    public int Id { get; set; }
    
    public int CharClassId { get; set; }
    public int CasterLevel { get; set; }
    
    public int SlotCount { get; set; }
    
    public SpellLevelType SpellLevelType { get; set; }
}