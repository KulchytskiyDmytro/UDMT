using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.DTO;

public class CharacterAttributeDto
{
    public int Id { get; set; }
    public int CharacterId { get; set; }

    public AttributeType AttributeType { get; set; }
    public int Value { get; set; }
}