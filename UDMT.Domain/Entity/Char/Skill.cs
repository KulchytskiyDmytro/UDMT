using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Entity.Char;

public class Skill
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
        
    public AttributeType AttributeType { get; set; }
}