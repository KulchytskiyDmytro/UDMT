using UDMT.Application.DTO;

namespace UDMT.Application.Services.Race_Subrace;

public interface IRaceService
{
    Task<ICollection<GetRacesDto>> GetRacesAsync(CancellationToken ct);
    Task<RaceDto> AddNewRace(RaceDto raceDto, CancellationToken ct);
    Task<RaceDto> UpdateRaceAsync(int raceId, RaceDto raceDto, CancellationToken ct);
    Task DeleteRaceAsync(int raceId, CancellationToken ct);
}