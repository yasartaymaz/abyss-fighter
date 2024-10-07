using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserWallets.Queries.GetById;

public class GetByIdUserWalletResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid DefinitionWalletTypeId { get; set; }
    public string? WalletAddress { get; set; }
}