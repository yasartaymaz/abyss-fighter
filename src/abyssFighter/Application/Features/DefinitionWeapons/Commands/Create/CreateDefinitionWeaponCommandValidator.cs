using FluentValidation;

namespace Application.Features.DefinitionWeapons.Commands.Create;

public class CreateDefinitionWeaponCommandValidator : AbstractValidator<CreateDefinitionWeaponCommand>
{
    public CreateDefinitionWeaponCommandValidator()
    {
        RuleFor(c => c.DefinitionWeaponTypeId).NotEmpty();
        RuleFor(c => c.IsOneHanded).NotNull();
        RuleFor(c => c.AttackPoints).NotNull();
        RuleFor(c => c.DefencePoints).NotNull();
        RuleFor(c => c.AttackSpeedMultiplier).NotNull();
    }
}