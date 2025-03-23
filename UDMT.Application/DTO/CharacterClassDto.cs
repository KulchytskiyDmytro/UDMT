using UDMT.Domain.Entity;

namespace UDMT.Application.DTO;

public class CharacterClassDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public ICollection<AttributeType> SavingThrowProficiencies { get; set; }
}