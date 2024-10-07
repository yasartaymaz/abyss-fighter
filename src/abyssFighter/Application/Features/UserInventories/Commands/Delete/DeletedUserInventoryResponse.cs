using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserInventories.Commands.Delete;

public class DeletedUserInventoryResponse : IResponse
{
    public Guid Id { get; set; }
}