using FluentValidation;

namespace Application.Features.DefinitionWeapons.Commands.Update;

public class UpdateDefinitionWeaponCommandValidator : AbstractValidator<UpdateDefinitionWeaponCommand>
{
    public UpdateDefinitionWeaponCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.DefinitionWeaponTypeId).NotEmpty();
        RuleFor(c => c.IsOneHanded).NotEmpty();
        RuleFor(c => c.AttackPoints).NotEmpty();
        RuleFor(c => c.AttackSpeedMultiplier).NotEmpty();
    }
}