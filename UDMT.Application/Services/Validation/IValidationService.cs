namespace UDMT.Application.Services.Validation;

public interface IValidationService
{
    
    /// <summary>
    /// Checks if this subclass is in chosen class 
    /// </summary>
    Task ValidateClassSubclassMatchAsync(int classId, int? subclassId);
    
    /// <summary>
    /// Checks if this ClassMechanic is in chosen class or subclass
    /// Also Checks double link to class and subclass
    /// </summary>
    Task ValidateMechanicClassMatchAsync(int? classId, int? subclassId);
}