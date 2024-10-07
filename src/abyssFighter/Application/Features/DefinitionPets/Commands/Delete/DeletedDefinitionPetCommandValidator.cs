using FluentValidation;

namespace Application.Features.DefinitionPets.Commands.Delete;

public class DeleteDefinitionPetCommandValidator : AbstractValidator<DeleteDefinitionPetCommand>
{
    public DeleteDefinitionPetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}