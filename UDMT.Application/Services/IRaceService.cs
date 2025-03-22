using UDMT.Application.DTO;

namespace UDMT.Application.Services;

public interface IRaceService
{
    Task<List<RaceDto>> GetRaceAsync();
    Task AddNewRace(RaceDto raceDto);
    Task UpdateRaceAsync(RaceDto raceDto);
    Task DeleteRaceAsync(int raceId);
}