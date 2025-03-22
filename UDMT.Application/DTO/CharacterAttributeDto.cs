using UDMT.Domain.Entity;

namespace UDMT.Application.DTO;

public class CharacterAttributeDto
{
    public int Id { get; set; }
    public int PlayerId { get; set; }

    public AttributeType AttributeType { get; set; }
    public int Value { get; set; }
}