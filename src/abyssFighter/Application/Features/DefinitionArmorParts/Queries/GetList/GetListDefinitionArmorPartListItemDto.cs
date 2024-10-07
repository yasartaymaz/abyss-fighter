using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DefinitionArmorParts.Queries.GetList;

public class GetListDefinitionArmorPartListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}