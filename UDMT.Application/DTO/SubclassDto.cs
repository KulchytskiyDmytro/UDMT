using UDMT.Application.DTO;

public class SubclassDto
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public bool IsHomebrew { get; set; }
    
    public bool GrantsMagic { get; set; }
    
    public int CharClassId { get; set; }
    
        
    public ICollection<ClassMechanicDto>  ClassMechanics { get; set; } = new List<ClassMechanicDto>();
    
    public ICollection<FeatureDto> Features { get; set; } = new List<FeatureDto>();
}