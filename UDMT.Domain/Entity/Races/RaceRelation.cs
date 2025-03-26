using System.ComponentModel.DataAnnotations;

namespace UDMT.Domain.Entity.Races;

public class RaceRelation
{
    [Key]
    public int Id { get; set; }
    public int RaceId { get; set; }
    public Race? Race { get; set; }

    public int? SubraceId { get; set; }
    public Race? Subrace { get; set; }
}