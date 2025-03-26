using UDMT.Application.DTO;

namespace UDMT.Application.Services.CharGenServices.Attributes;

public interface IAttributeService
{
    Task GenerateAttributesAsync(int characterId, int raceId);
}