namespace UDMT.Domain.Entity;

public class Race
{
    public int Id { get; set; }
    public required string Race_Name { get; set; }
    
    public string Description { get; set; }
    
    public int Atribute { get; set; }
}