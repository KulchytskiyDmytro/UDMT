using Mapster;
using NeerCore.DependencyInjection;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity.Char;

namespace UDMT.Application.Services;

[Service]
public class CharService : ICharService
{
    private readonly IAppDbContext _dbContext;

    public CharService(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
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

        return character.Adapt<CharDto>();
    }
}