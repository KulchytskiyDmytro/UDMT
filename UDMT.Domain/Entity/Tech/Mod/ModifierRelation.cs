namespace UDMT.Domain.Entity.Tech.Mod;

public class ModifierRelation
{
    public int Id { get; set; }
    
    public int SourceId { get; set; }
    
    public ModifierSourceType SourceType { get; set; }
    
    public int ModifierId { get; set; }
    
    public Modifier Modifier { get; set; }
}