using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Entity.Mechanics;

public class DamageFormula
{
    public int DiceCount { get; set; } = 1;
    public DiceType DiceType { get; set; } = DiceType.D6;
    public int FlatBonus { get; set; } = 0;
    public bool ScalesWithLevel { get; set; } = false;
}