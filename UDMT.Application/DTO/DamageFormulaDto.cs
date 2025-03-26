using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.DTO;

public class DamageFormulaDto
{
    public DiceType DiceType { get; set; }                     
    public Dictionary<int, int>? DiceByLevel { get; set; }     
    public int FlatBonus { get; set; } = 0;    
}