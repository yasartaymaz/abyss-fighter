using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DefinitionItemTypes.Queries.GetList;

public class GetListDefinitionItemTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}