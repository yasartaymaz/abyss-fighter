using FluentValidation;

namespace Application.Features.DefinitionWeapons.Commands.Create;

public class CreateDefinitionWeaponCommandValidator : AbstractValidator<CreateDefinitionWeaponCommand>
{
    public CreateDefinitionWeaponCommandValidator()
    {
        RuleFor(c => c.DefinitionWeaponTypeId).NotEmpty();
        RuleFor(c => c.IsOneHanded).NotEmpty();
        RuleFor(c => c.AttackPoints).NotEmpty();
        RuleFor(c => c.AttackSpeedMultiplier).NotEmpty();
    }
}