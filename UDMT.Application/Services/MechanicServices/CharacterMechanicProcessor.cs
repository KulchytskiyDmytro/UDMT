using NeerCore.DependencyInjection;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Characters;
using UDMT.Domain.Entity.Classes;
using UDMT.Domain.Entity.Mechanics;
using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.Services.MechanicServices;

[Service]
public class CharacterMechanicProcessor  : ICharacterMechanicProcessor
{
    private readonly AppDbContext _context;
    
    public CharacterMechanicProcessor(AppDbContext context)
    {
        _context = context;

    }

    private int CalculateDamage(DamageFormula damage, int level)
    {
        int total = damage.FlatBonus;

        if (damage.DiceCount > 0)
        {
            int dice = damage.DiceCount;

            if (damage.ScalesWithLevel)
            {
                dice *= level;
            }

            total += dice * ((int)damage.DiceType + 1) / 2; // середнє значення на кубику
        }

        return total;
    }

    // TODO: Add Mechanics
    public void ApplyMechanics(Character character)
    {
        var features = (character.CharClass.Features ?? Enumerable.Empty<Feature>())
            .Concat(character.Subclass?.Features ?? Enumerable.Empty<Feature>())
            .Where(f => f.ClassMechanic != null)
            .Select(f => f.ClassMechanic!);

        foreach (var mechanic in features)
        {
            switch (mechanic.Type)
            {
                case MechanicType.Modifier:
                    ApplyModifierMechanic(character, mechanic);
                    break;
            }
        }
    }
    
    private void ApplyModifierMechanic(Character character, ClassMechanic mechanic)
    {
        var data = mechanic.Data;

        if (data.Target == null) return;

        switch (data.Target)
        {
            case TargetType.SavingThrow:
                ApplySavingThrowModifier(character, data);
                break;

            case TargetType.HitPoints:
                ApplyHpModifier(character, data);
                break;

            case TargetType.Skill:
                ApplySkillModifier(character, data);
                break;

            case TargetType.TemporaryHP:
                // Not implemented yet
                break;

            case TargetType.AC:
                // TODO: Add logic for AC bonus
                break;

            default:
                break;
        }
    }
    
    private void ApplySavingThrowModifier(Character character, MechanicData data)
    {
        if (data.RelatedAttribute == null || data.BonusDamage == null) return;

        var savingThrow = character.SavingThrows
            .FirstOrDefault(s => s.AttributeType == data.RelatedAttribute);

        if (savingThrow != null)
        {
            int bonus = CalculateDamage(data.BonusDamage, 1);
            savingThrow.BonusOverride += bonus;
        }
    }
    
    private void ApplyHpModifier(Character character, MechanicData data)
    {
        if (data.BonusDamage != null)
        {
            int bonus = CalculateDamage(data.BonusDamage, 1);
            character.MaxHitPoints += bonus;
        }
    }
    
    private void ApplySkillModifier(Character character, MechanicData data)
    {
        if (data.GrantsSkillId != null)
        {
            var skillId = data.GrantsSkillId.Value;
            if (!character.Skills.Any(s => s.SkillId == skillId))
            {
                character.Skills.Add(new CharacterSkill
                {
                    SkillId = skillId,
                    CharacterId = character.Id,
                    IsProficient = true
                });
            }
        }
    }

}