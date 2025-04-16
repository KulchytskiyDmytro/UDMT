using UDMT.Domain.Entity.Magic;

namespace UDMT.Domain.Entity.Char;

public class CharSpell
{
    public int Id { get; set; }
    
    public int CharacterId { get; set; }
    
    public Character Character { get; set; }
    
    public ICollection<Spell> Spells { get; set; }
}