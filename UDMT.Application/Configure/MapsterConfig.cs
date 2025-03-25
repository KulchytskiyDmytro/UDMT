using Mapster;
using UDMT.Application.DTO;
using UDMT.Domain.Entity;

namespace UDMT.Application.Configure;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        // Character
        TypeAdapterConfig<CharacterAttributeDto, CharacterAttribute>.NewConfig();
        TypeAdapterConfig<CharacterDto, Character>
            .NewConfig()
            .Map(dest => dest.Attributes, src => src.CharacterAttributes.Adapt<ICollection<CharacterAttribute>>());

        
        TypeAdapterConfig<CharacterDto, Character>
            .NewConfig()
            .Map(dest => dest.Attributes, src => 
                src.CharacterAttributes.Adapt<ICollection<CharacterAttribute>>());
        
        TypeAdapterConfig<Character, CharacterDto>
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
        
            // Class
        TypeAdapterConfig<CharClass, CharClassDto>.NewConfig()
            .Map(dest => dest.SavingThrowProficiencies,
                src => src.SavingThrowProficiencies.Select(x => x.AttributeType).ToList());

    }   
}