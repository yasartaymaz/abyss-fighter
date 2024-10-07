using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionWalletTypes.Commands.Create;

public class CreatedDefinitionWalletTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}