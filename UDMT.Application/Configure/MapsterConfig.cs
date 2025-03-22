using Mapster;
using UDMT.Application.DTO;
using UDMT.Domain.Entity;

namespace UDMT.Application.Configure;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        // Player
        TypeAdapterConfig<CharacterAttributeDto, CharacterAttribute>.NewConfig();
        TypeAdapterConfig<PlayerDto, Player>
            .NewConfig()
            .Map(dest => dest.Attributes, src => src.CharacterAttributes.Adapt<ICollection<CharacterAttribute>>());

        
        TypeAdapterConfig<PlayerDto, Player>
            .NewConfig()
            .Map(dest => dest.Attributes, src => 
                src.CharacterAttributes.Adapt<ICollection<CharacterAttribute>>());
        
        TypeAdapterConfig<Player, PlayerDto>
            .NewConfig()
            .Map(dest => dest.CharacterAttributes, src => src.Attributes);
        
        // Race
        TypeAdapterConfig<RaceDto, Race>
            .NewConfig()
            .Map(dest => dest.AttributeBonuses, src => 
                src.AttributeBonuses.Select(b => new RaceAttributeBonus
                {
                    Id = b.Id,
                    AttributeType = b.AttributeType,
                    Value = b.Value
                }))
            .Map(dest => dest.RaceRelations, src => 
                src.RaceRelations.Select(r => new RaceRelation
                {
                    SubraceId = r.SubraceId
                }));
    }
}