namespace UDMT.Application.DTO;

public class SubRaceDto
{
    public required string Name { get; set; }
    public string Description { get; set; }

    public bool IsHomebrew { get; set; }
}