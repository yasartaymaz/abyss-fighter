using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionWeapons.Commands.Create;

public class CreatedDefinitionWeaponResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid DefinitionWeaponTypeId { get; set; }
    public string? Name { get; set; }
    public bool IsOneHanded { get; set; }
    public decimal AttackPoints { get; set; }
    public decimal AttackSpeedMultiplier { get; set; }
}