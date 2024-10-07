using FluentValidation;

namespace Application.Features.DefinitionPets.Commands.Create;

public class CreateDefinitionPetCommandValidator : AbstractValidator<CreateDefinitionPetCommand>
{
    public CreateDefinitionPetCommandValidator()
    {
        RuleFor(c => c.DefinitionPetTypeId).NotEmpty();
        RuleFor(c => c.AttackPoints).NotEmpty();
        RuleFor(c => c.DefencePoints).NotEmpty();
        RuleFor(c => c.HealthPoints).NotEmpty();
    }
}