namespace UDMT.Domain.Entity.Classes;

public class CharSubclass
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public bool IsHomebrew { get; set; }
    
    public bool GrantsMagic { get; set; }
    
    public int CharClassId { get; set; }
    public CharClass CharClass { get; set; }

    public ICollection<Feature> Features { get; set; } = new List<Feature>();

}