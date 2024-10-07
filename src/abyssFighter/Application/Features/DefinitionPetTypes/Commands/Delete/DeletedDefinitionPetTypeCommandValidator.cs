using FluentValidation;

namespace Application.Features.DefinitionPetTypes.Commands.Delete;

public class DeleteDefinitionPetTypeCommandValidator : AbstractValidator<DeleteDefinitionPetTypeCommand>
{
    public DeleteDefinitionPetTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}