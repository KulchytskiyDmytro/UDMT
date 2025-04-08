using UDMT.Domain.Entity.Inventory;

namespace UDMT.Domain.Entity.Char;

public class CharInventory
{
    public int Id { get; set; }
    
    public Guid ItemId { get; set; }
    
    public Item Item { get; set; }
    
    public int Quantity { get; set; }
    
    public Guid CharacterId { get; set; }
    
    public Character Character { get; set; }
}