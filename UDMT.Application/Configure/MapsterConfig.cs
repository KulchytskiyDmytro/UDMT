using Mapster;
using UDMT.Application.DTO;
using UDMT.Domain.Entity.Race_Subrace;

namespace UDMT.Application.Configure;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<RaceDto, Race>.NewConfig()
            .Ignore(dest => dest.SubRaces);
    }   
}