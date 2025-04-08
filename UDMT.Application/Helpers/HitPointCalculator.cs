using UDMT.Domain.Entity.Char;
using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.Helpers;

public static class HitPointCalculator
{
    public static void ApplyHp(this Character character)
    {
        var conBonus = character.Attributes
            .FirstOrDefault(a => a.AttributeType == AttributeType.Constitution);

        var finalBonus = conBonus?.BonusOverride ?? conBonus?.BonusModifier ?? 0;

        int conMod = GetConMod(finalBonus);

        var charClassLevel = character.ClassLevels
            .FirstOrDefault(c => c.CharacterId == character.Id);
        
        character.MaxHp = CalculateHpByLevel(charClassLevel.CharClass.HpDiceType, conMod, charClassLevel.Level);
        character.CurrentHp = character.MaxHp; // temp solution 
    }
    
    private static int GetConMod(int score)
        => AttributeUtils.GetModifier(score);

    private static int CalculateLevel1Hp(HpDiceType hpDice, int conMod)
        => (int)hpDice + conMod;

    private static int CalculateHpByLevel(HpDiceType hitDie, int conMod, int level)
    {
        if (level <= 1)
            return CalculateLevel1Hp(hitDie, conMod);

        int totalHp = (int)hitDie + conMod; // level 1
        int averagePerLevel = ((int)hitDie / 2) + 1;

        for (int lvl = 2; lvl <= level; lvl++)
            totalHp += averagePerLevel + conMod;

        return totalHp;
    }

}
