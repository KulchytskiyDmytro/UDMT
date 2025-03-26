using UDMT.Domain.Entity.Characters;
using UDMT.Domain.Entity.Classes;

namespace UDMT.Domain.Entity.Shared;

public class Skill
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public AttributeType AttributeType { get; set; }
    
    public ICollection<CharacterSkill> CharacterSkills { get; set; }
    public ICollection<ClassSkill> ClassSkills { get; set; }
}