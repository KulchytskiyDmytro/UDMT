namespace UDMT.Application.DTO;

public class SubraceDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }

    public bool IsHomebrew { get; set; }
    
    public int ParentRaceId { get; set; } // нет в бд используется для привязки
    
    public ICollection<RaceAttributeBonusDto> AttributeBonuses { get; set; }
}