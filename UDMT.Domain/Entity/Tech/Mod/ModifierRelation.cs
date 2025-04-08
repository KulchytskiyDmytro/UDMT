namespace UDMT.Domain.Entity.Tech.Mod;

public class ModifierRelation
{
    public int Id { get; set; }
    
    public Guid SourceId { get; set; }
    
    public ModifierSourceType SourceType { get; set; }
    
    public Guid ModifierId { get; set; }
    
    public Modifier Modifier { get; set; }
}