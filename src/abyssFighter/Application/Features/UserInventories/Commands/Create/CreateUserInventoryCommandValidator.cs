using FluentValidation;

namespace Application.Features.UserInventories.Commands.Create;

public class CreateUserInventoryCommandValidator : AbstractValidator<CreateUserInventoryCommand>
{
    public CreateUserInventoryCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.UserHeroId).NotEmpty();
        RuleFor(c => c.DefinitionItemId).NotEmpty();
        RuleFor(c => c.DefinitionItemTypeId).NotEmpty();
        RuleFor(c => c.Amount).NotEmpty();
    }
}