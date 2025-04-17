namespace UDMT.Application.DTO;

public interface IModifierContainer
{
    int Id { get; }
    ICollection<ModifierDto>? Modifiers { get; set; }
}