namespace UDMT.Domain.Entity.Tech.Fea;

public class FeatureRelation
{
    public int Id { get; set; }
    
    public int SourceId { get; set; }
    
    public FeatureSourceType SourceType { get; set; }
    
    public int FeatureId { get; set; }
    
    public Feature Feature { get; set; }
}