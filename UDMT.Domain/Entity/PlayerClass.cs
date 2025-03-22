namespace UDMT.Domain.Entity;

public class PlayerClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public ICollection<PlayerClassSavingThrow> SavingThrowProficiencies { get; set; } = new List<PlayerClassSavingThrow>();
}