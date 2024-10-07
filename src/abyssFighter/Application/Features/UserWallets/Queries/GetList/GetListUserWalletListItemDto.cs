using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserWallets.Queries.GetList;

public class GetListUserWalletListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid DefinitionWalletTypeId { get; set; }
    public string? WalletAddress { get; set; }
}