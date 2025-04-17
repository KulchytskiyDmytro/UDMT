using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using NeerCore.Exceptions;
using UDMT.Application.DTO;
using UDMT.Application.Services.CharData;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Char;

namespace UDMT.Application.Services;

[Service]
public class CharService : ICharService
{
    private readonly IAppDbContext _dbContext;
    private readonly ICharacterInitializationService _initialization;
    private readonly ICharacterRecalculationService _recalculation;

    public CharService(IAppDbContext dbContext,
        ICharacterInitializationService initialization,
        ICharacterRecalculationService recalculation)
    {
        _dbContext = dbContext;
        _initialization = initialization;
        _recalculation = recalculation;
    }

    public async Task<CharDto> GetChar(int charId, CancellationToken ct)
    {
        var character = await _dbContext.Set<Character>()
            .FirstOrDefaultAsync(c => c.Id == charId, cancellationToken: ct);

        if (character is null) throw new NotFoundException($"There is no such Character with Id: {charId}");

        return character.Adapt<CharDto>();
    }

    public async Task<CharDto> CreateChar(CharDto dto, CancellationToken ct)
    {
        var character = new Character()
        {
            Name = dto.Name,
            PlayerName = dto.PlayerName,
            RaceId = dto.RaceId,
            BackgroundId = dto.BackgroundId
        };

        await _dbContext.Set<Character>().AddAsync(character, ct);
        await _dbContext.SaveChangesAsync(ct);

        // Create Attributes/SavingThrows/Skills
        await _initialization.InitializeCharacterAsync(character.Id, ct);
        
        await _recalculation.RecalculateCharacterStateAsync(character.Id, ct);
        
        return character.Adapt<CharDto>();
    }
    
}