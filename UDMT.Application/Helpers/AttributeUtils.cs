using UDMT.Application.DTO;

namespace UDMT.Application.Helpers;

public static class AttributeUtils
{
    /// <summary>
    /// Calculates the ability modifier from an attribute score.
    /// DnD 5e: (score - 10) / 2, rounded down.
    /// </summary>
    public static int GetModifier(int score)
    {
        return (int)Math.Floor((score - 10) / 2.0);
    }
    
    /// <summary>
    /// Calculates total saving throw bonus.
    /// </summary>
    public static int GetSavingThrowBonus(this CharacterSavingThrowDto savingThrowDto, int score)
    {
        int modifier = GetModifier(score);
        int res = modifier + (savingThrowDto.IsProficient ? savingThrowDto.ProficiencyBonus : 0) + savingThrowDto.BonusOverride;
        return res;
    }
    
    /// <summary>
    /// Calculates total skill bonus.
    /// </summary>
    public static int GetSkillBonus(int score, bool isProficient, bool hasExpertise, int proficiencyBonus, int bonusOverride = 0)
    {
        int modifier = GetModifier(score);
        int prof = 0;

        if (hasExpertise)
            prof = proficiencyBonus * 2;
        else if (isProficient)
            prof = proficiencyBonus;

        return modifier + prof + bonusOverride;
    }
}