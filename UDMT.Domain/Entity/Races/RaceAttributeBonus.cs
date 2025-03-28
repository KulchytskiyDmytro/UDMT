﻿using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Entity.Races;

public class RaceAttributeBonus
{
    public int Id { get; set; }

    public AttributeType AttributeType { get; set; }
    public int Value { get; set; }

    public int RaceId { get; set; }
    public Race Race { get; set; }
}