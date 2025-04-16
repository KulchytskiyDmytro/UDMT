using UDMT.Domain.Entity.Inventory;

namespace UDMT.Domain.Entity.Char;

public class CharInventory
{
    public int Id { get; set; }
    
    public int ItemId { get; set; }
    
    public Item Item { get; set; }
    
    public int Quantity { get; set; }
    
    public int CharacterId { get; set; }
    
    public Character Character { get; set; }
}