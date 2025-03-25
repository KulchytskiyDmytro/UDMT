using UDMT.Application.DTO;

namespace UDMT.Application.Services.CharGenServices.Class;

public interface IClassService
{
    Task<ICollection<CharClassDto>> GetAllClassesAsync();
    Task<int> AddClassAync(CharClassDto charClassDto);
    Task UpdateClassAsync(CharClassDto charClassDto);
    Task DeleteClassAsync(int classId);

}