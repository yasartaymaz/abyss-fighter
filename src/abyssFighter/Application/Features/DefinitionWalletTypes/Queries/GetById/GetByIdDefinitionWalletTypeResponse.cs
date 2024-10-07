using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionWalletTypes.Queries.GetById;

public class GetByIdDefinitionWalletTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}