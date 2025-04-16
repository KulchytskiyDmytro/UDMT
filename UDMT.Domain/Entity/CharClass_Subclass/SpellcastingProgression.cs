using UDMT.Domain.Entity.Magic;

namespace UDMT.Domain.Entity.CharClass_Subclass;

public class SpellcastingProgression
{
    public int Id { get; set; }
    
    public int CharClassId { get; set; }
    
    public CharClass CharClass { get; set; }
    
    public int CasterLevel { get; set; }
    
    public int SlotCount { get; set; }
    
    public SpellLevelType SpellLevelType { get; set; }
}