namespace UDMT.Domain.Entity;

public class CharacterClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public ICollection<ClassSavingThrow> SavingThrowProficiencies { get; set; } = new List<ClassSavingThrow>();
}