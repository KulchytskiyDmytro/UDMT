using UDMT.Domain.Entity.Mechanics;

namespace UDMT.Application.DTO;

public class ClassMechanicDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public bool IsHomebrew { get; set; }
    public MechanicType Type { get; set; }

    public MechanicDataDto Data { get; set; } = new();
}