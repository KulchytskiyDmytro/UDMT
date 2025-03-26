using UDMT.Domain.Entity.Characters;

namespace UDMT.Application.Services.MechanicServices;

public interface ICharacterMechanicProcessor
{
    /// <summary>
    /// Застосовує механіки класу та підкласу до персонажа.
    /// Наприклад: бонуси до спасбросків, навичок, HP тощо.
    /// </summary>
    /// <param name="character">Повністю завантажений персонаж з класом, підкласом, фічами та механіками.</param>
    void ApplyMechanics(Character character);
}