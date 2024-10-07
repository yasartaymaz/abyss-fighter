using FluentValidation;

namespace Application.Features.DefinitionPetTypes.Commands.Create;

public class CreateDefinitionPetTypeCommandValidator : AbstractValidator<CreateDefinitionPetTypeCommand>
{
    public CreateDefinitionPetTypeCommandValidator()
    {
        //RuleFor(c => c.IsAttack).NotEmpty();
        //RuleFor(c => c.IsDefence).NotEmpty();
        //RuleFor(c => c.IsHybrid).NotEmpty();
    }
}