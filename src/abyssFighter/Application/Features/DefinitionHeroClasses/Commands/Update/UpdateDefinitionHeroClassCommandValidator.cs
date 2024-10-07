using FluentValidation;

namespace Application.Features.DefinitionHeroClasses.Commands.Update;

public class UpdateDefinitionHeroClassCommandValidator : AbstractValidator<UpdateDefinitionHeroClassCommand>
{
    public UpdateDefinitionHeroClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.HealthPoints).NotEmpty();
        RuleFor(c => c.AttackPoints).NotEmpty();
        RuleFor(c => c.DefencePoints).NotEmpty();
        RuleFor(c => c.AttackSpeedMultiplier).NotEmpty();
    }
}