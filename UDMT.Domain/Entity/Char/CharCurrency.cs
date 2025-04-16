namespace UDMT.Domain.Entity.Char;

public class CharCurrency
{
    public int Id { get; set; }
    
    public int CurrencyTypeId { get; set; }
    
    public Currency Currency { get; set; }
    
    public int Amount { get; set; }
    
    public int CharacterId { get; set; }
    
    public Character Character { get; set; }
}