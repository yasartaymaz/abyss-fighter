using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserInventoryEquippedItems.Commands.Delete;

public class DeletedUserInventoryEquippedItemResponse : IResponse
{
    public Guid Id { get; set; }
}