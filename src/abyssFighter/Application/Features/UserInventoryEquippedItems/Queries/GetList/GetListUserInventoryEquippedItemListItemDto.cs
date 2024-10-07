using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserInventoryEquippedItems.Queries.GetList;

public class GetListUserInventoryEquippedItemListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid UserHeroId { get; set; }
    public Guid RightHand { get; set; }
    public Guid LeftHand { get; set; }
    public bool IsWeaponOneHanded { get; set; }
    public Guid ArmorId { get; set; }
    public Guid ConsumableSlot { get; set; }
    public decimal Amount { get; set; }
}