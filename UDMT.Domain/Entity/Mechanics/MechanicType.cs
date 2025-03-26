namespace UDMT.Domain.Entity.Mechanics;

public enum MechanicType
{
    Resource,           // Очки: Rage, Ki, Sorcery Points
    Modifier,           // Модификатор: скорость, урон, AC
    PassiveAbility,     // Постоянная способность (e.g. Deflect Missiles)
    ActionReaction,     // Используется как реакция или действие
    Custom              // Для особых случаев
}