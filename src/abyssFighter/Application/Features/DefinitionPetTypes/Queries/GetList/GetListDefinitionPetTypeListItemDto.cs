using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DefinitionPetTypes.Queries.GetList;

public class GetListDefinitionPetTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public bool IsAttack { get; set; }
    public bool IsDefence { get; set; }
    public bool IsHybrid { get; set; }
}