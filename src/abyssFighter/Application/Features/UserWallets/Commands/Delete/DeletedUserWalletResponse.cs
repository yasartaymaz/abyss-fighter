using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserWallets.Commands.Delete;

public class DeletedUserWalletResponse : IResponse
{
    public Guid Id { get; set; }
}