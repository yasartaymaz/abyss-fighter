using FluentValidation;

namespace Application.Features.UserInventoryEquippedItems.Commands.Create;

public class CreateUserInventoryEquippedItemCommandValidator : AbstractValidator<CreateUserInventoryEquippedItemCommand>
{
    public CreateUserInventoryEquippedItemCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.UserHeroId).NotEmpty();
        RuleFor(c => c.RightHand).NotEmpty();
        RuleFor(c => c.LeftHand).NotEmpty();
        RuleFor(c => c.IsWeaponOneHanded).NotNull();
        RuleFor(c => c.ArmorId).NotEmpty();
        RuleFor(c => c.ConsumableSlot).NotEmpty();
        RuleFor(c => c.Amount).NotEmpty();
    }
}