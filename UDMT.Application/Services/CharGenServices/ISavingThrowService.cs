using UDMT.Application.DTO;

namespace UDMT.Application.Services.CharGenServices;

public interface ISavingThrowService
{
    Task<ICollection<SavingThrowDto>> SavingThrowAsync(int playerId);
}