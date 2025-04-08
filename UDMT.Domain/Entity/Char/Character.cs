﻿using UDMT.Domain.Entity.Back;
using UDMT.Domain.Entity.Race_Subrace;

namespace UDMT.Domain.Entity.Char;

public class Character
{
    public Guid Id { get; set; }
    
    public string? PlayerName { get; set; }
    
    public int Level { get; set; }
    
    public string? Alignment  { get; set; }
    
    public string? Gender { get; set; }
    
    public string? Deity { get; set; }
        
    public string? Backstory { get; set; }
    
    public Guid RaceId { get; set; }
    public Race Race { get; set; }
    
    public Guid BackgroundId { get; set; }
    public Background Background { get; set; }

    public ICollection<CharClassLevel> ClassLevels { get; set; }
    
    public ICollection<CharAttribute> Attributes { get; set; }
    
    public ICollection<CharSavingThrow> SavingThrows { get; set; }
    
    public ICollection<CharSkill> Skills { get; set; }

    public ICollection<CharSpell>? Spells { get; set; }
    
    public ICollection<CharInventory>? Inventory { get; set; }
    
    public ICollection<CharCurrency>? Currency { get; set; }
    
    public int MaxHp { get; set; }
    
    public int CurrentHp { get; set; }
    
    public int? TemporaryHp { get; set; }
    
    public int? OverrideCurrentHp { get; set; }
    
    public int? OverrideTemporaryHp { get; set; }
}