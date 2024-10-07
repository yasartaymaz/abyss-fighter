using FluentValidation;

namespace Application.Features.DefinitionHeroClasses.Commands.Delete;

public class DeleteDefinitionHeroClassCommandValidator : AbstractValidator<DeleteDefinitionHeroClassCommand>
{
    public DeleteDefinitionHeroClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}