using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DefinitionWeapons.Queries.GetList;

public class GetListDefinitionWeaponListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid DefinitionWeaponTypeId { get; set; }
    public string? Name { get; set; }
    public bool IsOneHanded { get; set; }
    public decimal AttackPoints { get; set; }
    public decimal AttackSpeedMultiplier { get; set; }
}