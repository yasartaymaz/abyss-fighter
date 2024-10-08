using FluentValidation;

namespace Application.Features.DefinitionItems.Commands.Create;

public class CreateDefinitionItemCommandValidator : AbstractValidator<CreateDefinitionItemCommand>
{
    public CreateDefinitionItemCommandValidator()
    {
        RuleFor(c => c.DefinitionItemTypeId).NotEmpty();
        RuleFor(c => c.ItemId).NotEmpty();
        RuleFor(c => c.IsStackable).NotNull();
        RuleFor(c => c.IsWeapon).NotNull();
        RuleFor(c => c.IsArmor).NotNull();
    }
}