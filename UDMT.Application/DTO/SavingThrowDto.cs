using UDMT.Domain.Entity;

namespace UDMT.Application.DTO;

public class SavingThrowDto
{
    public AttributeType Attribute { get; set; }
    public bool IsProficient { get; set; }
    public int Bonus { get; set; }
}