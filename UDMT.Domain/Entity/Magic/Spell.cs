using UDMT.Domain.Entity.Char;

namespace UDMT.Domain.Entity.Magic;

public class Spell
{
    public int Id { get; set; }
    
    public int CharSpellId { get; set; }
    
    public CharSpell CharSpell { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public SpellType SpellType { get; set; }

    public SpellSchoolType SpellSchoolType { get; set; }
    
    public ICollection<SpellClass> SpellClasses { get; set; }
    
    public CastTimeType CastTimeType { get; set; }
    
    public int? Distance { get; set; }
    
    public ComponentsType? ComponentsType { get; set; }
    
    public string? Duration { get; set; }
    
    public SpellLevelType SpellLevelType { get; set; }
    
    public bool IsRitual { get; set; }
    
    public bool RequiresConcentration { get; set; }
}