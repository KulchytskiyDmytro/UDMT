namespace UDMT.Application.DTO;

public class RaceDto
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    public string Description { get; set; }

    public bool IsHomebrew { get; set; }
    public bool IsRequireSubrace { get; set; }
    
    public ICollection<RaceRelationDto>? RaceRelations { get; set; }
    public ICollection<RaceAttributeBonusDto> AttributeBonuses { get; set; }
}