using UDMT.Domain.Entity.Mechanics;

namespace UDMT.Domain.Entity.Classes;

public class ClassMechanic
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    
    public bool IsHomebrew { get; set; }

    public MechanicType Type { get; set; }
    
    public MechanicData Data { get; set; } = new MechanicData();
}