﻿namespace UDMT.Domain.Entity.Back;

public class Background
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsHomebrew { get; set; }
}