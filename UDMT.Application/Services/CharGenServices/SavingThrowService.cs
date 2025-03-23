using Microsoft.EntityFrameworkCore;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;

namespace UDMT.Application.Services.CharGenServices;

public class SavingThrowService : ISavingThrowService
{
    private readonly AppDbContext _context;

    public SavingThrowService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<SavingThrowDto>> CalcSavingThrowAsync(int characterId)
    {
        var character = await _context.Characters
            .Include(p => p.Attributes)
            .Include(p => p.CharacterClass)
            .ThenInclude(pc => pc.SavingThrowProficiencies)
            .FirstOrDefaultAsync(p => p.Id == characterId);

        if (character is null)
        {
            throw new Exception($"Character with Id={characterId} not found.");
        }

        var proficiencyBonus = character.ProficencyBonus;

        return Enum.GetValues<AttributeType>().Select(attr =>
        {
            int score = character.Attributes.FirstOrDefault(a => a.AttributeType == attr)?.Value ?? 10;
            var modifier = (score - 10) / 2;
            var isProficient = character.CharacterClass.SavingThrowProficiencies?
                .Any(p => p.AttributeType == attr) == true;

            return new SavingThrowDto
            {
                Attribute = attr,
                IsProficient = isProficient,
                
            };
        }).ToList();
    }
}