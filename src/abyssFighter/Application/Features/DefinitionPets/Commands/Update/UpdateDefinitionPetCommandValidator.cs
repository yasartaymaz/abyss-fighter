using FluentValidation;

namespace Application.Features.DefinitionPets.Commands.Update;

public class UpdateDefinitionPetCommandValidator : AbstractValidator<UpdateDefinitionPetCommand>
{
    public UpdateDefinitionPetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.DefinitionPetTypeId).NotEmpty();
        RuleFor(c => c.AttackPoints).NotEmpty();
        RuleFor(c => c.DefencePoints).NotEmpty();
        RuleFor(c => c.HealthPoints).NotEmpty();
    }
}