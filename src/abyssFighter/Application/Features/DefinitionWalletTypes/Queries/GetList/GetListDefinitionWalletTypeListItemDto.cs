using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DefinitionWalletTypes.Queries.GetList;

public class GetListDefinitionWalletTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}