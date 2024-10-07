using FluentValidation;

namespace Application.Features.DefinitionWeaponTypes.Commands.Create;

public class CreateDefinitionWeaponTypeCommandValidator : AbstractValidator<CreateDefinitionWeaponTypeCommand>
{
    public CreateDefinitionWeaponTypeCommandValidator()
    {
        RuleFor(c => c.IsOneHanded).NotEmpty();
    }
}