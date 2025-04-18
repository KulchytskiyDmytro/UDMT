﻿namespace UDMT.Domain.Entity.Char;

public class Currency
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public decimal ExchangeRateToGold { get; set; }
}