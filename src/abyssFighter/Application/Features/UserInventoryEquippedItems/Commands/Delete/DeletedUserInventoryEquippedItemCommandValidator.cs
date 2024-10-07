using FluentValidation;

namespace Application.Features.UserInventoryEquippedItems.Commands.Delete;

public class DeleteUserInventoryEquippedItemCommandValidator : AbstractValidator<DeleteUserInventoryEquippedItemCommand>
{
    public DeleteUserInventoryEquippedItemCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}