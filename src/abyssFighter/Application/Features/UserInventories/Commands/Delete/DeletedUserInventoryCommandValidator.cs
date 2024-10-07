using FluentValidation;

namespace Application.Features.UserInventories.Commands.Delete;

public class DeleteUserInventoryCommandValidator : AbstractValidator<DeleteUserInventoryCommand>
{
    public DeleteUserInventoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}