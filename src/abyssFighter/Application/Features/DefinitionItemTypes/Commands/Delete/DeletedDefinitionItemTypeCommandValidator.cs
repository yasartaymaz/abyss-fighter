using FluentValidation;

namespace Application.Features.DefinitionItemTypes.Commands.Delete;

public class DeleteDefinitionItemTypeCommandValidator : AbstractValidator<DeleteDefinitionItemTypeCommand>
{
    public DeleteDefinitionItemTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}