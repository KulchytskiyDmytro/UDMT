using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.DTO;

public class CharClassDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public bool HasMagic { get; set; }
    public bool IsHomebrew { get; set; }
    
    public HpDieType HitDie { get; set; }
    
    public ICollection<AttributeType>? SavingThrowProficiencies { get; set; } = new List<AttributeType>();
    
    public ICollection<SubclassDto>? Subclasses { get; set; } = new List<SubclassDto>();
    
    public ICollection<FeatureDto>? Features { get; set; } = new List<FeatureDto>();
}