namespace UDMT.Domain.Entity.Classes;

public class Feature
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Level { get; set; }
    
    public bool GrantsMagic { get; set; } = false;
    public bool IsHomebrew { get; set; } = false;

    public int? CharClassId { get; set; }
    public CharClass? CharClass { get; set; }

    public int? CharSubclassId { get; set; }
    public CharSubclass? CharSubclass { get; set; }

    public int? ClassMechanicId { get; set; }
    public ClassMechanic? ClassMechanic { get; set; }
}