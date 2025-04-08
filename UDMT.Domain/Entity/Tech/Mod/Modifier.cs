﻿using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Entity.Tech.Mod;

public class Modifier
{
    public int Id { get; set; }
    
    public ModifierType ModifierType { get; set; }
    
    public AttributeType AttributeType { get; set; }
    
    public int Value { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
}