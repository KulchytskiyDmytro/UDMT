using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Entity;

public class Skill
{
    public int Id { get; set; }
    
    public string Name { get; set; }
        
    public AttributeType AttributeType { get; set; }
}