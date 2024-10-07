using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionWalletTypes.Commands.Update;

public class UpdatedDefinitionWalletTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}