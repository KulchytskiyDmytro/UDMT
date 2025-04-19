using UDMT.Application.DTO.Class_Subclass;

namespace UDMT.Application.Services.Class_Subclass;

public interface IClassService
{
    Task<ICollection<GetClassDto>> GetClassesAsync(CancellationToken ct);
    Task<ClassDto> AddNewClass(ClassDto classDto, CancellationToken ct);
    Task<ClassDto> UpdateClassAsync(int classId, ClassDto raceDto, CancellationToken ct);
    Task DeleteClassAsync(int classId, CancellationToken ct);
}