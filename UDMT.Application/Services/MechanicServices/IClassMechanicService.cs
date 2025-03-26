using UDMT.Application.DTO;

namespace UDMT.Application.Services.MechanicServices;

public interface IClassMechanicService
{
    Task<ICollection<ClassMechanicDto>> GetAllClassMechanicsAsync();
    
    Task<int> AddClassMechanicAsync(ClassMechanicDto classMechanicDto);
    
    Task UpdateClassMechanicAsync(int classMechanicId, ClassMechanicDto classMechanicDto);
    
    Task DeleteClassMechanicAsync(int classMechanicId);
}