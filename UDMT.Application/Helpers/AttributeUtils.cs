using UDMT.Application.DTO;
using UDMT.Domain.Entity.Tech.Mod;

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
    /// Calculates saving throw bonus based on Attribute and Prof
    /// </summary>
    public static int GetSavingThrowBonus(this CharSavingThrowDto savingThrowDto, int score, int proficiencyBonus)
    {
        int attributeModifier = GetModifier(score);
        
        int total = attributeModifier 
                    + (savingThrowDto.IsProficient ? proficiencyBonus : 0);
        
        int res = savingThrowDto?.BonusOverride ?? total;
        
        return res;
    }
    
    /// <summary>
    /// Calculates total skill bonus.
    /// (It's raw method so it doesn't work right now)
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