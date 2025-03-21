namespace UDMT.Domain.Entity;

public class Player
{
    public int Id { get; set; }
    public string PlayerName { get; set; }
    public int RaceId { get; set; }
    public int PlayerClassId { get; set; }

    public Race Race { get; set; }
    public PlayerClass PlayerClass { get; set; }
    
    public List<CharacterAttribute> Attributes { get; set; }
}