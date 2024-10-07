using FluentValidation;

namespace Application.Features.DefinitionWeaponTypes.Commands.Update;

public class UpdateDefinitionWeaponTypeCommandValidator : AbstractValidator<UpdateDefinitionWeaponTypeCommand>
{
    public UpdateDefinitionWeaponTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.IsOneHanded).NotEmpty();
    }
}