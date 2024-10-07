using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionWalletTypes.Commands.Delete;

public class DeletedDefinitionWalletTypeResponse : IResponse
{
    public Guid Id { get; set; }
}