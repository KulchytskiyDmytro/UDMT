using UDMT.Application.DTO;

namespace UDMT.Application.Services;

public interface IBackgroundService
{
    Task<ICollection<GetBackgroundsDto>> GetBackgroundAsync(CancellationToken ct);
    Task<BackgroundDto> AddNewBackground(BackgroundDto backgroundDto, CancellationToken ct);
    Task<BackgroundDto> UpdateBackgroundAsync(int bgId, BackgroundDto backgroundDto, CancellationToken ct);
    Task DeleteBackgroundAsync(int bgId, CancellationToken ct);
}