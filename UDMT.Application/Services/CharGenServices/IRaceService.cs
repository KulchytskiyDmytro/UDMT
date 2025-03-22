using UDMT.Application.DTO;

namespace UDMT.Application.Services;

public interface IRaceService
{
    Task<List<RaceDto>> GetRacesAsync();
    Task AddNewRace(RaceDto raceDto);
    Task UpdateRaceAsync(RaceDto raceDto);
    Task DeleteRaceAsync(int raceId);
}