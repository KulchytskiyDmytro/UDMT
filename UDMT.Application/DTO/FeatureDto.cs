namespace UDMT.Application.DTO;

public class FeatureDto
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int? Level { get; set; }

    public bool GrantsMagic { get; set; }
    public bool IsHomebrew { get; set; }

    public int? CharClassId { get; set; }
    public int? CharSubclassId { get; set; }

    public int? ClassMechanicId { get; set; }
    public ClassMechanicDto? ClassMechanic { get; set; }

}