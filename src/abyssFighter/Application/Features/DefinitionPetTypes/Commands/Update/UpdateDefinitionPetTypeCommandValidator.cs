using FluentValidation;

namespace Application.Features.DefinitionPetTypes.Commands.Update;

public class UpdateDefinitionPetTypeCommandValidator : AbstractValidator<UpdateDefinitionPetTypeCommand>
{
    public UpdateDefinitionPetTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.IsAttack).NotEmpty();
        RuleFor(c => c.IsDefence).NotEmpty();
        RuleFor(c => c.IsHybrid).NotEmpty();
    }
}