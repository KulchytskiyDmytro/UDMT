using UDMT.Application.DTO;
using UDMT.Domain.Entity.Characters;
using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.Helpers;

public static class HitPointCalculator
{
    public static int GetConMod(int score)
        => AttributeUtils.GetModifier(score);

    public static int CalculateLevel1Hp(HpDieType hitDie, int conMod)
        => (int)hitDie + conMod;
    
    public static int CalculateHpByLevel(HpDieType hitDie, int conMod, int level = 1)
    {
        if (level <= 1)
            return CalculateLevel1Hp(hitDie, conMod);

        int totalHp = (int)hitDie + conMod; // level 1
        int averagePerLevel = ((int)hitDie / 2) + 1;

        for (int lvl = 2; lvl <= level; lvl++)
            totalHp += averagePerLevel + conMod;

        return totalHp;
    }

    public static void ApplyHp(this Character character, int level = 1)
    {
        var conScore = character.Attributes
            .FirstOrDefault(a => a.AttributeType == AttributeType.Constitution)?.Value ?? 10;

        int conMod = GetConMod(conScore);
        character.MaxHitPoints = CalculateHpByLevel(character.CharClass.HitDie, conMod, level);
        character.CurrentHitPoints = character.MaxHitPoints;
    }

    public static void ApplyHp(this CharacterDto character, int level = 1)
    {
        var conScore = character.CharacterAttributes
            .FirstOrDefault(a => a.AttributeType == AttributeType.Constitution)?.Value ?? 10;

        int conMod = GetConMod(conScore);
        character.MaxHitPoints = CalculateHpByLevel(character.CharClass.HitDie, conMod, level);
        character.CurrentHitPoints = character.MaxHitPoints;
    }
}
