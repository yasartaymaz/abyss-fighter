using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DefinitionArmorTypes.Queries.GetList;

public class GetListDefinitionArmorTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}