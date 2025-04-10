﻿using UDMT.Domain.Entity.Shared;

namespace UDMT.Application.DTO;

public class CharacterSavingThrowDto
{
    public AttributeType AttributeType { get; set; }
    
    public int BonusModifier { get; set; }
    
    public int BonusOverride { get; set; }
    
    public bool IsProficient { get; set; }
    
    public Guid CharacterId { get; set; }
}