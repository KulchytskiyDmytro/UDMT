﻿using Mapster;
using Microsoft.EntityFrameworkCore;
using NeerCore.DependencyInjection;
using UDMT.Application.DTO;
using UDMT.Domain.Context;
using UDMT.Domain.Entity;

namespace UDMT.Application.Services.CharGenServices;

[Service]
public class CharacterService : ICharacterService
{
    private readonly AppDbContext _context;
    private ICharacterService _characterServiceImplementation;
    private readonly ISavingThrowService _savingThrowService;

    public CharacterService(AppDbContext context, ISavingThrowService savingThrowService)
    {
        _context = context;
        _savingThrowService = savingThrowService;
    }
    
    public async Task<ICollection<CharacterDto>> GetCharactersAsync()
    {
        var characters = await _context.Characters
            .Include(p => p.Attributes)
            .Include(p => p.CharClass)
            .ThenInclude(pc => pc.SavingThrowProficiencies)
            .ToListAsync(); // <- обычный fetch

        var charactersAsync = characters.Adapt<List<CharacterDto>>();
        
        foreach (var dto in charactersAsync)
        {
            dto.CharacterAttributes = await GenerateAttributesAsync(dto.Id, dto.RaceId);
            dto.SavingThrowDtos = await _savingThrowService.GetSavingThrowsAsync(dto.Id);
        }

        return charactersAsync;
    }

    public async Task<CharacterDto?> GetCharacterByIdAsync(int characterId)
    {
        var character = await _context.Characters
            .Include(p => p.Attributes)
            .Include(p => p.CharClass)
            .ThenInclude(pc => pc.SavingThrowProficiencies)
            .FirstOrDefaultAsync(p => p.Id == characterId);

        if (character is null)
            return null;

        var dto = character.Adapt<CharacterDto>();
        
        await GenerateAttributesAsync(characterId, dto.RaceId);
        
        dto.SavingThrowDtos = await _savingThrowService.GetSavingThrowsAsync(characterId);
        
        return dto;
    }

    public async Task<int> AddNewCharacter(CharacterDto characterDto)
    {
        var character = characterDto.Adapt<Character>();
        _context.Characters.Add(character);
        await _context.SaveChangesAsync(); // получить character.Id

        await GenerateAttributesAsync(character.Id, characterDto.RaceId);
        
        await _savingThrowService.InitializeForCharacterAsync(character.Id, characterDto.CharClassId);
        
        return character.Id;
    }

    public async Task<ICollection<CharacterAttributeDto>> GenerateAttributesAsync(int characterId, int raceId)
    {
        var character = await _context.Characters
            .Include(p => p.Attributes)
            .FirstOrDefaultAsync(p => p.Id == characterId);

        if (character == null)
            throw new Exception($"Character {characterId} not found");

        character.Attributes.Clear(); // на случай перегенерации

        var raceBonuses = await _context.RaceAttributeBonuses
            .Where(rb => rb.RaceId == raceId)
            .ToListAsync();

        foreach (AttributeType type in Enum.GetValues<AttributeType>())
        {
            var bonus = raceBonuses.FirstOrDefault(rb => rb.AttributeType == type)?.Value ?? 0;
            character.Attributes.Add(new CharacterAttribute
            {
                AttributeType = type,
                Value = 8 + bonus
            });
        }

        await _context.SaveChangesAsync();

        return character.Attributes.Adapt<ICollection<CharacterAttributeDto>>();
    }
    

    public async Task UpdateCharacterAsync(CharacterDto characterDto)
    {
        var character = await _context.Characters
            .Include(p => p.Attributes)
            .FirstOrDefaultAsync(p => p.Id == characterDto.Id);

        if (character == null)
            throw new Exception($"Character Id={characterDto.Id} не найден");

        // Обновить свойства
        characterDto.Adapt(character); // in-place map

        // Обновить атрибуты вручную
        character.Attributes = characterDto.CharacterAttributes.Adapt<ICollection<CharacterAttribute>>();

        await _context.SaveChangesAsync();
    }

    public async Task DeleteCharacterAsync(int characterId)
    {
        var character = await _context.Characters.FirstOrDefaultAsync(p => p.Id == characterId);
        if (character != null) _context.Characters.Remove(character);
        await _context.SaveChangesAsync();
    }
}