using UDMT.Application.DTO;

namespace UDMT.Application.Services.CharGenServices.Subclass;

public interface ISubclassService
{
    Task<List<SubclassDto>> GetSubclassAsync();
    Task AddNewSubclassAsync(SubclassDto subclassDto);
    Task UpdateSubclassAsync(SubclassDto subclassDto);
    Task DeleteSubclassAsync(int subclassId);
}