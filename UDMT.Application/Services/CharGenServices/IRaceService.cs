using UDMT.Application.DTO;

namespace UDMT.Application.Services.CharGenServices;

public interface IRaceService
{
    Task<ICollection<RaceDto>> GetRacesAsync();
    Task AddNewRace(RaceDto raceDto);
    Task UpdateRaceAsync(RaceDto raceDto);
    Task DeleteRaceAsync(int raceId);
}