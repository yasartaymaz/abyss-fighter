using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DefinitionWeaponTypes.Queries.GetList;

public class GetListDefinitionWeaponTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public bool IsOneHanded { get; set; }
}