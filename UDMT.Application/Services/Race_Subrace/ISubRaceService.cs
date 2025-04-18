using UDMT.Application.DTO;

namespace UDMT.Application.Services.Race_Subrace;

public interface ISubRaceService
{
    Task<SubRaceDto> CreateSubraceAsync(int raceId, SubRaceDto dto, CancellationToken ct);
    Task<SubRaceDto> UpdateSubraceAsync(int raceId, SubRaceDto subRaceDto, CancellationToken ct);
    Task DeleteSubraceAsync(int raceId, CancellationToken ct);
}