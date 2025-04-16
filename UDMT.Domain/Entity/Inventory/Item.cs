namespace UDMT.Domain.Entity.Inventory;

public class Item
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public decimal? Weight { get; set; }
    
    public bool IsHomebrew { get; set; }
    
    public ItemType ItemType { get; set; }
}