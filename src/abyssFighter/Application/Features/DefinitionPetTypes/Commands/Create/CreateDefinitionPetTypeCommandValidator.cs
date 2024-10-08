using FluentValidation;

namespace Application.Features.DefinitionPetTypes.Commands.Create;

public class CreateDefinitionPetTypeCommandValidator : AbstractValidator<CreateDefinitionPetTypeCommand>
{
    public CreateDefinitionPetTypeCommandValidator()
    {
        RuleFor(c => c.IsAttack).NotNull();
        RuleFor(c => c.IsDefence).NotNull();
        RuleFor(c => c.IsHybrid).NotNull();
    }
}