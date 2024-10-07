using FluentValidation;

namespace Application.Features.UserInventoryEquippedItems.Commands.Update;

public class UpdateUserInventoryEquippedItemCommandValidator : AbstractValidator<UpdateUserInventoryEquippedItemCommand>
{
    public UpdateUserInventoryEquippedItemCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.UserHeroId).NotEmpty();
        RuleFor(c => c.RightHand).NotEmpty();
        RuleFor(c => c.LeftHand).NotEmpty();
        RuleFor(c => c.IsWeaponOneHanded).NotEmpty();
        RuleFor(c => c.ArmorId).NotEmpty();
        RuleFor(c => c.ConsumableSlot).NotEmpty();
        RuleFor(c => c.Amount).NotEmpty();
    }
}