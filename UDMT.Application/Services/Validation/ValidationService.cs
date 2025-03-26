using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using UDMT.Domain.Context;

namespace UDMT.Application.Services.Validation;

[Service]
public class ValidationService : IValidationService
{
      private readonly AppDbContext _context;

      public ValidationService(AppDbContext context)
      {
            _context = context;
      }
      
      /// <summary>
      /// Checks if this subclass is in chosen class 
      /// </summary>
      public async Task ValidateClassSubclassMatchAsync(int classId, int? subclassId)
      {
            if (subclassId is null)
                  return;

            var subclass = await _context.CharSubclasses.FindAsync(subclassId.Value);
            if (subclass == null || subclass.CharClassId != classId)
            {
                  throw new InvalidOperationException($"Selected subclass {subclassId} does not belong to the selected class {classId}.");
            }
      }
      
      /// <summary>
      /// Checks if this ClassMechanic is in chosen class or subclass
      /// Also Checks double link to class and subclass
      /// </summary>
      public async Task ValidateMechanicClassMatchAsync(int? classId, int? subclassId)
      {
            if (classId != null && subclassId != null)
                  throw new InvalidOperationException("Entity cannot belong to both class and subclass.");
            
            if (classId == null && subclassId == null)
                  throw new InvalidOperationException("Entity must belong to either a class or a subclass.");
            
            if (classId != null)
            {
                  var exists = await _context.CharClasses.AnyAsync(c => c.Id == classId);
                  if (!exists)
                        throw new InvalidOperationException($"Class with Id {classId} does not exist.");
            }
            
            if (subclassId != null)
            {
                  var exists = await _context.CharSubclasses.AnyAsync(s => s.Id == subclassId);
                  if (!exists)
                        throw new InvalidOperationException($"Subclass with Id {subclassId} does not exist.");
            }
      }
      
}