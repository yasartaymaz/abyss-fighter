using FluentValidation;

namespace Application.Features.DefinitionHeroClasses.Commands.Create;

public class CreateDefinitionHeroClassCommandValidator : AbstractValidator<CreateDefinitionHeroClassCommand>
{
    public CreateDefinitionHeroClassCommandValidator()
    {
        RuleFor(c => c.HealthPoints).NotEmpty();
        RuleFor(c => c.AttackPoints).NotEmpty();
        RuleFor(c => c.DefencePoints).NotEmpty();
        RuleFor(c => c.AttackSpeedMultiplier).NotEmpty();
    }
}