namespace UDMT.Application.DTO;

public interface IModifierContainer
{
    int Id { get; set; }
    ICollection<ModifierDto>? Modifiers { get; set; }
}