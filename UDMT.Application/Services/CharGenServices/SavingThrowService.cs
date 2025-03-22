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
    
    public async Task<ICollection<SavingThrowDto>> SavingThrowAsync(int playerId)
    {
        var player = await _context.Players
            .Include(p => p.Attributes)
            .Include(p => p.PlayerClass)
            .ThenInclude(pc => pc.SavingThrowProficiencies)
            .FirstOrDefaultAsync(p => p.Id == playerId);

        if (player is null)
        {
            throw new Exception($"Player with Id={playerId} not found.");
        }

        var proficiencyBonus = player.ProficencyBonus;

        return Enum.GetValues<AttributeType>().Select(attr =>
        {
            int score = player.Attributes.FirstOrDefault(a => a.AttributeType == attr)?.Value ?? 10;
            var modifier = (score - 10) / 2;
            var isProficient = player.PlayerClass.SavingThrowProficiencies?
                .Any(p => p.AttributeType == attr) == true;

            return new SavingThrowDto
            {
                Attribute = attr,
                IsProficient = isProficient,
                Bonus = modifier + (isProficient ? proficiencyBonus : 0)
            };
        }).ToList();
    }
}