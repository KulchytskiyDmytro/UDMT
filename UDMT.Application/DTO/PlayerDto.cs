using UDMT.Domain.Entity;

namespace UDMT.Application.DTO;

public class PlayerDto
{
    public int Id { get; set; }
    
    public string PlayerName { get; set; }
    
    public int RaceId { get; set; }
    
    public int PlayerClassId { get; set; }
    
    public ICollection<CharacterAttributeDto> CharacterAttributes { get; set; }
}