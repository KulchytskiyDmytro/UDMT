namespace UDMT.Application.DTO;

public class RaceRelationDto
{
    public int Id { get; set; }
    
    public int? RaceId { get; set; }

    public int? SubraceId { get; set; }
    
    public SubraceDto Subrace { get; set; }
}