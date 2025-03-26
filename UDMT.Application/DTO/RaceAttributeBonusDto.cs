using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.DTO;

public class RaceAttributeBonusDto
{
    public int Id { get; set; }

    public AttributeType AttributeType { get; set; }
    public int Value { get; set; }

    public int RaceId { get; set; }

}