using UDMT.Application.DTO;

namespace UDMT.Application.Services;

public interface ICharService
{
    Task<CharDto> CreateChar(CharDto dto, CancellationToken ct);
}