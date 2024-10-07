using FluentValidation;

namespace Application.Features.UserInventories.Commands.Update;

public class UpdateUserInventoryCommandValidator : AbstractValidator<UpdateUserInventoryCommand>
{
    public UpdateUserInventoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.UserHeroId).NotEmpty();
        RuleFor(c => c.DefinitionItemId).NotEmpty();
        RuleFor(c => c.DefinitionItemTypeId).NotEmpty();
        RuleFor(c => c.Amount).NotEmpty();
    }
}