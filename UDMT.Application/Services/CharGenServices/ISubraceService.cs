using UDMT.Application.DTO;

namespace UDMT.Application.Services;

public interface ISubraceService
{
    Task<List<SubraceDto>> GetSubRacesAsync();
    Task AddNewSubRaceAsync(SubraceDto subraceDto);
    Task UpdateSubRaceAsync(SubraceDto subraceDto);
    Task DeleteSubRaceAsync(int subraceId);
}