using System.ComponentModel.DataAnnotations;

namespace UDMT.Domain.Entity;

public class Race
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }

    public bool IsHomebrew { get; set; }
    public bool IsRequireSubrace { get; set; }

    public ICollection<RaceRelation>? RaceRelations { get; set; }
    public ICollection<RaceAttributeBonus>? AttributeBonuses { get; set; }
}