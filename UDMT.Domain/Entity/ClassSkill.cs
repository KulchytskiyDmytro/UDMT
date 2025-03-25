﻿namespace UDMT.Domain.Entity;

public class ClassSkill
{
    public int Id { get; set; }

    public int CharClassId { get; set; }
    public CharClass CharClass { get; set; }

    public int SkillId { get; set; }
    public Skill Skill { get; set; }
    
    public bool IsProficient { get; set; }
}