using UDMT.Domain.Entity;

namespace UDMT.Application.DTO;

public class SavingThrowDto
{
    public AttributeType Attribute { get; set; }
    public bool IsProficient { get; set; }

    public int AttributeModifier { get; set; }
    public int ProficiencyBonus { get; set; }
    public int BonusOverride { get; set; }

    public int Total { get; set; }
}